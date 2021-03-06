﻿/// <binding AfterBuild='default' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var cssmin = require("gulp-cssmin");
var concat = require('gulp-concat');
var del = require('del');
var merge = require('merge-stream');

gulp.task("pack-css", function () {

	del([
		'wwwroot/dist/css/*'
	]);

	var streams = [
		gulp.src(["wwwroot/site/css/*.css"])
			.pipe(cssmin())
			.pipe(concat("site.min.css"))
			.pipe(gulp.dest("wwwroot/dist/css"))
	];

	return merge(streams);
});

gulp.task("pack-js", function () {

	del([
		'wwwroot/dist/js/*'
	]);

	var streams = [
		gulp.src(["wwwroot/site/js/*.js"])
			.pipe(uglify())
			.pipe(concat("site.min.js"))
			.pipe(gulp.dest("wwwroot/dist/js"))
	];

	return merge(streams);
});

// Dependency Dirs
var deps = {
	"jquery": {
		"dist/*": ""
	},
	"jquery-validation": {
		"dist/**/*": ""
	},
	"jquery-validation-unobtrusive": {
		"dist/*": ""
	},
	"popper.js": {
		"dist/**/*": ""
	},
	"bootstrap": {
		"dist/**/*": ""
	},
	"font-awesome": {
		"/**/*": ""
	}
};

gulp.task('cleanVendor', function () {
	return del([
		// here we use a globbing pattern to match everything inside the `mobile` folder
		'wwwroot/vendor/*'
		//'wwwroot/dist/*'
	]);
});

gulp.task("scripts", ['cleanVendor'], function () {

	del([
		// here we use a globbing pattern to match everything inside the `mobile` folder
		'wwwroot/vendor/*'
		//'wwwroot/dist/*'
	]);

	var streams = [];

	for (var prop in deps) {
		console.log("Prepping Scripts for: " + prop);
		for (var itemProp in deps[prop]) {
			console.log("Copy: " + itemProp + " to : " + deps[prop][itemProp]);
			streams.push(gulp.src("./node_modules/" + prop + "/" + itemProp)
				.pipe(gulp.dest("./wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
		}
	}

	return merge(streams);

});

gulp.task("default", ['pack-css', 'pack-js', 'scripts'], function () { });