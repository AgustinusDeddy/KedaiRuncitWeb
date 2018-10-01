var target = Argument("target", "Default");
var tag = Argument("tag", "cake");

Task("Clean")  
  .Does(() =>
{
  if (DirectoryExists("./KedaiRuncitWeb/bin/"))
  {
    CleanDirectory("./KedaiRuncitWeb/bin/");
  }
  if (DirectoryExists("./KedaiRuncitWeb/obj/"))
  {
    CleanDirectory("./KedaiRuncitWeb/obj/");
  }
  if (DirectoryExists("./KedaiRuncitWeb/wwwroot/dist"))
  {
    CleanDirectory("./KedaiRuncitWeb/wwwroot/dist");
  }
  if (DirectoryExists("./KedaiRuncitWeb/wwwroot/vendor"))
  {
    CleanDirectory("./KedaiRuncitWeb/wwwroot/vendor");
  }

});

Task("Restore")
  .Does(() =>
{
    DotNetCoreRestore(".");
});

Task("Build")
  .Does(() =>
{
    DotNetCoreBuild(".", new DotNetCoreBuildSettings
	  {
		  Configuration = "Release"
	  });
});

Task("Default")
	.IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build");

 Task("Rebuild")
	.IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build");


RunTarget(target);