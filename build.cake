var target = Argument("target", "Default");
var tag = Argument("tag", "cake");

var projects = GetFiles("./**/*.csproj");
var projectPaths = projects.Select(project => project.GetDirectory().ToString());

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context =>
{
    Information("Running tasks...");
});

Teardown(context =>
{
    Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")  
  .Description("Cleans all directories that are used during the build process.")
  .Does(() =>
{
	var settings = new DeleteDirectorySettings {
        Recursive = true,
        Force = true
    };

	// Clean solution directories.
    foreach(var path in projectPaths)
    {
        Information($"Cleaning path {path} ...");
        var directoriesToDelete = new DirectoryPath[]{
            Directory($"{path}/obj"),
            Directory($"{path}/bin")
        };
        foreach(var dir in directoriesToDelete)
        {
            if (DirectoryExists(dir))
            {
                DeleteDirectory(dir, settings);
            }
        }
    }

});

Task("Restore")
    .Description("Restores all the NuGet packages that are used by the specified solution.")
    .Does(() =>
{
    // Restore all NuGet packages.
    foreach(var path in projectPaths)
    {
        Information($"Restoring {path}...");
        DotNetCoreRestore(path);
    }
});

Task("Build")
  .Does(() =>
{
	var settings = new DotNetCoreBuildSettings
     {
         Framework = "netcoreapp2.1",
         Configuration = "Release"
     };

    //DotNetCoreBuild(".");

    DotNetCoreBuild("./KedaiRuncitWeb/KedaiRuncitWeb.csproj", settings);

});

Task("Test")
	.Description("Run all unit tests within the project.")
  .Does(() =>
{
    var files = GetFiles("KedaiRuncitWeb.UnitTests/**/*.csproj");


    foreach(var file in files)
    {
        DotNetCoreTest(file.ToString());
    }
});

Task("Publish")
  .Does(() =>
{
    var settings = new DotNetCorePublishSettings
    {
		Framework = "netcoreapp2.1",
        Configuration = "Release",
        OutputDirectory = "./publish",
        Runtime = "win-x64",
        VersionSuffix = tag
    };
                
    DotNetCorePublish(".", settings);
});

Task("Default")
	.IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
	.IsDependentOn("Test");
    //.IsDependentOn("Publish");

 Task("Rebuild")
	.IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build");


RunTarget(target);