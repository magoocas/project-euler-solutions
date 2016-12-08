param(
	[Alias('n')][Parameter(Mandatory=$true)][int]$number,
	[Alias('a')][switch]$dontAddToProject,
	[Alias('r')][switch]$restart
) 

$level = "{0:00}" -f [Math]::Floor((($number-1)/25 + 1))
$padded_number = "{0:000}" -f $number
$outputFile = "Level$level/Solution$padded_number.cs"

if( -not (Test-Path "Level$level/Solution$padded_number.cs") -or $restart)
{
    [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]'Ssl3,Tls,Tls11,Tls12'
	$pageUrl = "https://projecteuler.net/problem=$number"
	$pageHtml = Invoke-WebRequest $pageUrl
    $title = ($pageHtml.AllElements |? { $_.tagName -imatch "H2"}).innerText
    $description = ($pageHtml.AllElements |? { $_.class -match "problem_content" }).innerText.Split(@("`r`n"),[StringSplitOptions]::RemoveEmptyEntries) | foreach { "       " + $_ } | Out-String

    $source = 
@"
/*
    Problem: $number

    Title: $title

    Description:
$description
*/

namespace csharp.Level$level
{
    public class Solution$padded_number : SolutionBase
    {
        public override object Answer()
        {
			return 0;
        }
    }
}
"@

    Set-Content -Path $outputFile -Value $source
}

if(-not $dontAddToProject)
{
    $csproj = [xml](Get-Content csharp.csproj)
    if($csproj.SelectNodes("//*[contains(@Include,'Solution$padded_number.cs')]").Count -eq 0)
    {
        $group = $csproj.SelectSingleNode("//*[@Include='Properties\AssemblyInfo.cs']").ParentNode
        $node = [xml] @"
<root xmlns=`"http://schemas.microsoft.com/developer/msbuild/2003`">
    <Compile Include=`"Level$level\Solution$padded_number.cs`"/>
</root>
"@
        
        [void]$group.AppendChild($csproj.ImportNode($node.root.Compile,$true))
        $csproj.Save($(Resolve-Path csharp.csproj))
    }
}