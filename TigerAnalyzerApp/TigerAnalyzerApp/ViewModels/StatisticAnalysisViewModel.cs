using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using DynamicData;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace TigerAnalyzerApp.ViewModels;

public class StatisticAnalysisViewModel
{
    public IEnumerable<ScoutEntry>? ScoutData;
    public Dictionary<int, List<ScoutEntry>>? TeamData;
    public List<RobotTeam> Teams;

    public class RobotTeam
    {
        


        public int TeamNumber { get; set; }

        public double AutoAccuracy { get; set; } = 0; //
        public double AutoLowerAccuracy { get; set; } = 0; //d
        public double AutoUpperAccuracy { get; set; } = 0; //d
        
        public double AverageSpeed { get; set; } = 0; // 

        public double TotalLowerAccuracy { get; set; } = 0; // d
        public double TotalUpperAccuracy { get; set; } = 0; //d
        public double TotalClimbAttemptLength { get; set; } = 0; //d
       
        public double TotalClimbSuccessLength { get; set; } = 0; // d
        public double ClimbHighSuccessLength { get; set; } = 0; //d
        public double ClimbLowSuccessLength { get; set; } = 0; //d
        public double ClimbMiddleSuccessLength { get; set; } = 0; //d
        public double ClimbTraversalSuccessLength { get; set; } = 0; //d

        public double ClimbAttemptRate { get; set; } = 0; // dont need
        public double ClimbSuccessRate { get; set; } = 0; //
        public double AverageClimbHeight { get; set; } = 0; //
       
        public double TeleopAccuracy { get; set; } = 0; //
        public double TeleopLowerAccuracy { get; set; } = 0; //d
        public double TeleopUpperAccuracy { get; set; } = 0; //d
        
        public double AutoScoredCargo { get; set; } = 0; //
        public double AutoLowerScoredCargo { get; set; } = 0; //d
        public double AutoUpperScoredCargo { get; set; } = 0; //d
        
        public double TotalScoredCargo { get; set; } = 0; //
        public double TotalLowerScoredCargo { get; set; } = 0; //d
        public double TotalUpperScoredCargo { get; set; } = 0; //d
        
        public double TeleopScoredCargo { get; set; } = 0; //
        public double TeleopLowerScoredCargo { get; set; } = 0; //d
        public double TeleopUpperScoredCargo { get; set; } = 0; //d
        
        public RobotTeam (int teamNumber)
        {
            TeamNumber = teamNumber;
        }
    }
    
    public class ScoutEntry
    {
        [Name("Date")]
        public int Date { get; set; }
        [Name("Team Number")]
        public int TeamNumber { get; set; }
        [Name("Match Type")]
        public string MatchType { get; set; }
        [Name("Is Red Alliance")]
        public bool IsRedAlliance { get; set; }
        [Name("Game Year")]
        public int GameYear { get; set; }
        [Name("Comments")]
        public string Comments { get; set; }
        [Name("Auto Cargo Scoring Accuracy (All)")]
        public double AutoAccuracy { get; set; }
        [Name("Auto Cargo Scoring Accuracy (Lower)")]
        public double AutoLowerAccuracy { get; set; }
        [Name("Auto Cargo Scoring Accuracy (Upper)")]
        public double AutoUpperAccuracy { get; set; }
        [Name("Average Robot Speed (ft/s)")]
        public double AverageSpeed { get; set; }
        [Name("Cargo Scoring Accuracy (Lower)")]
        public double TotalLowerAccuracy { get; set; }
        [Name("Cargo Scoring Accuracy (Upper)")]
        public double TotalUpperAccuracy { get; set; }
        [Name("Climb Attempt Length")]
        public double TotalClimbAttemptLength { get; set; }
        [Name("Climb Success Length")]
        public double TotalClimbSuccessLength { get; set; }
        [Name("Climb Success Length (High)")]
        public double ClimbHighSuccessLength { get; set; }
        [Name("Climb Success Length (Low)")]
        public double ClimbLowSuccessLength { get; set; }
        [Name("Climb Success Length (Middle)")]
        public double ClimbMiddleSuccessLength { get; set; }
        [Name("Climb Success Length (Traversal)")]
        public double ClimbTraversalSuccessLength { get; set; }
        [Name("Did Auto Taxi")]
        public double DidAutoTaxi { get; set; }
        [Name("Did Climb Attempt")]
        public double DidClimbAttempt { get; set; }
        [Name("Did Climb Successfully")]
        public double DidClimbSuccessfully { get; set; }
        [Name("Did Climb Successfully (High)")]
        public double DidHighClimbSuccessfully { get; set; }
        [Name("Did Climb Successfully (Middle)")]
        public double DidMiddleClimbSuccessfully { get; set; }
        [Name("Did Climb Successfully (Traversal)")]
        public double DidTraversalClimbSuccessfully { get; set; }
        [Name("Teleop Cargo Scoring Accuracy (All)")]
        public double TeleopAccuracy { get; set; }
        [Name("Teleop Cargo Scoring Accuracy (Lower)")]
        public double TeleopLowerAccuracy { get; set; }
        [Name("Teleop Cargo Scoring Accuracy (Upper)")]
        public double TeleopUpperAccuracy { get; set; }
        [Name("Total Auto Cargo Missed (All)")]
        public double AutoMissedCargo { get; set; }
        [Name("Total Auto Cargo Missed (Lower)")]
        public double AutoLowerMissedCargo { get; set; }
        [Name("Total Auto Cargo Missed (Upper)")]
        public double AutoUpperMissedCargo { get; set; }
        [Name("Total Auto Cargo Scored (All)")]
        public double AutoScoredCargo { get; set; }
        [Name("Total Auto Cargo Scored (Lower)")]
        public double AutoLowerScoredCargo { get; set; }
        [Name("Total Auto Cargo Scored (Upper)")]
        public double AutoUpperScoredCargo { get; set; }
        [Name("Total Cargo Missed (All)")]
        public double TotalMissedCargo { get; set; }
        [Name("Total Cargo Missed (Lower)")]
        public double TotalLowerMissedCargo { get; set; }
        [Name("Total Cargo Missed (Upper)")]
        public double TotalUpperMissedCargo { get; set; }
        [Name("Total Cargo Scored (All)")]
        public double TotalScoredCargo { get; set; }
        [Name("Total Cargo Scored (Lower)")]
        public double TotalLowerScoredCargo { get; set; }
        [Name("Total Cargo Scored (Upper)")]
        public double TotalUpperScoredCargo { get; set; }
        [Name("Total Teleop Cargo Missed (All)")]
        public double TeleopMissedCargo { get; set; }
        [Name("Total Teleop Cargo Missed (Lower)")]
        public double TeleopLowerMissedCargo { get; set; }
        [Name("Total Teleop Cargo Missed (Upper)")]
        public double TeleopUpperMissedCargo { get; set; }
        [Name("Total Teleop Cargo Scored (All)")]
        public double TeleopScoredCargo { get; set; }
        [Name("Total Teleop Cargo Scored (Lower)")]
        public double TeleopLowerScoredCargo { get; set; }
        [Name("Total Teleop Cargo Scored (Upper)")]
        public double TeleopUpperScoredCargo { get; set; }

        
    }

    
   
    private static IEnumerable<ScoutEntry> GetScoutData(string path)
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = Encoding.UTF8,
            Delimiter = ",",
            IgnoreBlankLines = true,
            MissingFieldFound = null
            };
        

        FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        StreamReader textReader = new StreamReader(fs, Encoding.UTF8);
        CsvReader csv = new CsvReader(textReader, configuration);
        csv.Context.TypeConverterOptionsCache.GetOptions<string>().NullValues.Add("NaN");
        csv.Context.TypeConverterOptionsCache.GetOptions<double>().NullValues.Add("NaN");
        
        IEnumerable<ScoutEntry> data = csv.GetRecords<ScoutEntry>().ToList();
        return data;
    
    }

    private static Dictionary<int, List<ScoutEntry>> PackageTeamsTogether(IEnumerable<ScoutEntry> data)
    {
        var output = new Dictionary<int, List<ScoutEntry>>();   
        foreach (ScoutEntry entry in data)
        {
            if (!output.ContainsKey(entry.TeamNumber))
            {
                output[entry.TeamNumber] = new List<ScoutEntry>();
            }
            output[entry.TeamNumber].Add(entry);
        }

        return output;
    }

    private static ScoutEntry AverageEntries(List<ScoutEntry> entries)
    {
        ScoutEntry output = new ScoutEntry();
        PropertyInfo[] scoutProperties = typeof(ScoutEntry).GetProperties();
        foreach (PropertyInfo property in scoutProperties)
        {
            if (property.PropertyType != typeof(double)) {continue;}

            double finalValue = 0.0;
            foreach (ScoutEntry entry in entries)
            {
                finalValue += (double)property.GetValue(entry);
            }

            finalValue /= entries.Count;
            property.SetValue(output, finalValue);
        }

        return output;
    }
    
    private static List<RobotTeam> GenerateTeams(Dictionary<int, List<ScoutEntry>> teamData)
    {
        var teams = new List<RobotTeam>();

        foreach (var entry in  teamData)
        {
            RobotTeam team = new RobotTeam(entry.Key);
            List<ScoutEntry> matches = entry.Value;
            ScoutEntry average = AverageEntries(matches);

            Dictionary<string, double> averagedProperties = new Dictionary<string, double>();
            foreach (var scoutProperty in typeof(ScoutEntry).GetProperties())
            { 
                
                if (scoutProperty.PropertyType != typeof(double)) continue;
                
                averagedProperties.Add(scoutProperty.Name, (double) scoutProperty.GetValue(average));
                
                
            }
            PropertyInfo[] robotTeamProperties = typeof(RobotTeam).GetProperties();
            
            foreach (var teamProperty in robotTeamProperties)
            {
                if (averagedProperties.ContainsKey(teamProperty.Name))
                {
                    teamProperty.SetValue(team, averagedProperties[teamProperty.Name]);
                }
            }
            teams.Add(team);
        }
        
        return teams;
    }

    public StatisticAnalysisViewModel(string? dataPath)
    {
        if (dataPath != null)
        {
            ScoutData = GetScoutData(dataPath);
            TeamData = PackageTeamsTogether(ScoutData);
            Teams = GenerateTeams(TeamData);

            foreach (var robotTeam in Teams)
            {
                var radialData = new PolarLineSeries<int>();
                
                List<int> radialValues = new List<int>();
                foreach (var teamProperty in typeof(RobotTeam).GetProperties())
                {
                    if (teamProperty.PropertyType != typeof(double)) continue;
                    // DONT FORGET: DELETE THIS IF...JUST TEMP FOR PRESENTATION
                    if ((double) teamProperty.GetValue(robotTeam) < 5 && (double) teamProperty.GetValue(robotTeam) > 0)
                    {
                        radialValues.Add((int) Math.Round((double) teamProperty.GetValue(robotTeam) * 10));
                    }
                }

                radialData.Values = radialValues.ToArray();
                radialData.LineSmoothness = 0;
                radialData.GeometrySize = 0;
                radialData.Name = robotTeam.TeamNumber.ToString();
                

                RadialSeries.Add(radialData);
            }

        }
    }
    public ObservableCollection<ISeries> RadialSeries { get; set; } = new ObservableCollection<ISeries>();
    
    
}