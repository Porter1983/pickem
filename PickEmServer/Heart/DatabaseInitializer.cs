﻿using Marten;
using PickEmServer.Api.Models;
using PickEmServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickEmServer.Heart
{
    public class DatabaseInitializer
    {
        private readonly IDocumentStore _documentStore;

        public DatabaseInitializer(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public JobResult InitDatabase()
        {
            JobResult jobResult = new JobResult();
            jobResult.Messages = new List<string>();
            int count;

            count = this.LoadLeagues();
            jobResult.Messages.Add(string.Format("Added ({0}) Leagues", count));

            count = this.LoadSeasons();
            jobResult.Messages.Add(string.Format("Added ({0}) Seasons", count));

            count = this.LoadTeams();
            jobResult.Messages.Add(string.Format("Added ({0}) Teams", count));

            count = this.LoadWeeks();
            jobResult.Messages.Add(string.Format("Added ({0}) Weeks", count));

            jobResult.Success = true;
            return jobResult;
        }

        private int LoadLeagues()
        {
            using (var dbSession = _documentStore.LightweightSession())
            {
                dbSession.Store(new LeagueData { LeagueCode = "NeOnYa", LeagueTitle = "Did you get NeOnYa?" });
                dbSession.Store(new LeagueData { LeagueCode = "BurlMafia", LeagueTitle = "Burlington Mafia" });
                dbSession.SaveChanges();

                return 2;
            }
        }

        private int LoadSeasons()
        {
            using (var dbSession = _documentStore.LightweightSession())
            {
                dbSession.Store(new SeasonData { SeasonCode = "18", SeasonTitle = "2018" });
                dbSession.SaveChanges();

                return 1;
            }
        }

        private int LoadTeams()
        {
            using (var dbSession = _documentStore.LightweightSession())
            {
                dbSession.Store(new TeamData { TeamCode = "air-force", ShortName = "", LongName = "", NcaaNameSeo = "air-force", theSpreadName = "", icon24FileName = "air-force.24.png" });
                dbSession.Store(new TeamData { TeamCode = "akron", ShortName = "", LongName = "Akron", NcaaNameSeo = "akron", theSpreadName = "Akron", icon24FileName = "akron.24.png" });
                dbSession.Store(new TeamData { TeamCode = "alabama", ShortName = "", LongName = "Alabama", NcaaNameSeo = "alabama", theSpreadName = "Alabama", icon24FileName = "alabama.24.png" });
                dbSession.Store(new TeamData { TeamCode = "albany-ny", ShortName = "", LongName = "", NcaaNameSeo = "albany-ny", theSpreadName = "", icon24FileName = "albany-ny.24.png" });
                dbSession.Store(new TeamData { TeamCode = "alcorn-st", ShortName = "", LongName = "", NcaaNameSeo = "alcorn-st", theSpreadName = "", icon24FileName = "alcorn-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "appalachian-st", ShortName = "", LongName = "Appalachian St", NcaaNameSeo = "appalachian-st", theSpreadName = "Appalachian St", icon24FileName = "appalachian-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "arizona-st", ShortName = "", LongName = "", NcaaNameSeo = "arizona-st", theSpreadName = "", icon24FileName = "arizona-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "arizona", ShortName = "", LongName = "Arizona", NcaaNameSeo = "arizona", theSpreadName = "Arizona", icon24FileName = "arizona.24.png" });
                dbSession.Store(new TeamData { TeamCode = "arkansas-st", ShortName = "", LongName = "Arizona State", NcaaNameSeo = "arkansas-st", theSpreadName = "Arizona State", icon24FileName = "arkansas-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "arkansas", ShortName = "", LongName = "", NcaaNameSeo = "arkansas", theSpreadName = "", icon24FileName = "arkansas.24.png" });
                dbSession.Store(new TeamData { TeamCode = "army", ShortName = "", LongName = "Army", NcaaNameSeo = "army", theSpreadName = "Army", icon24FileName = "army.24.png" });
                dbSession.Store(new TeamData { TeamCode = "auburn", ShortName = "", LongName = "Auburn", NcaaNameSeo = "auburn", theSpreadName = "Auburn", icon24FileName = "auburn.24.png" });
                dbSession.Store(new TeamData { TeamCode = "austin-peay", ShortName = "", LongName = "", NcaaNameSeo = "austin-peay", theSpreadName = "", icon24FileName = "austin-peay.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ball-st", ShortName = "", LongName = "", NcaaNameSeo = "ball-st", theSpreadName = "", icon24FileName = "ball-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "baylor", ShortName = "", LongName = "", NcaaNameSeo = "baylor", theSpreadName = "", icon24FileName = "baylor.24.png" });
                dbSession.Store(new TeamData { TeamCode = "boise-st", ShortName = "", LongName = "Boise State", NcaaNameSeo = "boise-st", theSpreadName = "Boise State", icon24FileName = "boise-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "boston-college", ShortName = "", LongName = "Boston College", NcaaNameSeo = "boston-college", theSpreadName = "Boston College", icon24FileName = "boston-college.24.png" });
                dbSession.Store(new TeamData { TeamCode = "bowling-green", ShortName = "", LongName = "Bowling Green", NcaaNameSeo = "bowling-green", theSpreadName = "Bowling Green", icon24FileName = "bowling-green.24.png" });
                dbSession.Store(new TeamData { TeamCode = "buffalo", ShortName = "", LongName = "", NcaaNameSeo = "buffalo", theSpreadName = "", icon24FileName = "buffalo.24.png" });
                dbSession.Store(new TeamData { TeamCode = "byu", ShortName = "", LongName = "", NcaaNameSeo = "byu", theSpreadName = "", icon24FileName = "byu.24.png" });
                dbSession.Store(new TeamData { TeamCode = "california", ShortName = "", LongName = "California", NcaaNameSeo = "california", theSpreadName = "California", icon24FileName = "california.24.png" });
                dbSession.Store(new TeamData { TeamCode = "central-ark", ShortName = "", LongName = "", NcaaNameSeo = "central-ark", theSpreadName = "", icon24FileName = "central-ark.24.png" });
                dbSession.Store(new TeamData { TeamCode = "central-conn-st", ShortName = "", LongName = "", NcaaNameSeo = "central-conn-st", theSpreadName = "", icon24FileName = "central-conn-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "central-mich", ShortName = "", LongName = "Central Michigan", NcaaNameSeo = "central-mich", theSpreadName = "Central Michigan", icon24FileName = "central-mich.24.png" });
                dbSession.Store(new TeamData { TeamCode = "charleston-so", ShortName = "", LongName = "", NcaaNameSeo = "charleston-so", theSpreadName = "", icon24FileName = "charleston-so.24.png" });
                dbSession.Store(new TeamData { TeamCode = "charlotte", ShortName = "", LongName = "", NcaaNameSeo = "charlotte", theSpreadName = "", icon24FileName = "charlotte.24.png" });
                dbSession.Store(new TeamData { TeamCode = "cincinnati", ShortName = "", LongName = "Cincinnati", NcaaNameSeo = "cincinnati", theSpreadName = "Cincinnati", icon24FileName = "cincinnati.24.png" });
                dbSession.Store(new TeamData { TeamCode = "clemson", ShortName = "", LongName = "", NcaaNameSeo = "clemson", theSpreadName = "", icon24FileName = "clemson.24.png" });
                dbSession.Store(new TeamData { TeamCode = "coastal-caro", ShortName = "", LongName = "Coastal Carolina", NcaaNameSeo = "coastal-caro", theSpreadName = "Coastal Carolina", icon24FileName = "coastal-caro.24.png" });
                dbSession.Store(new TeamData { TeamCode = "colorado-st", ShortName = "", LongName = "Colorado State", NcaaNameSeo = "colorado-st", theSpreadName = "Colorado State", icon24FileName = "colorado-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "colorado", ShortName = "", LongName = "Colorado", NcaaNameSeo = "colorado", theSpreadName = "Colorado", icon24FileName = "colorado.24.png" });
                dbSession.Store(new TeamData { TeamCode = "delaware-st", ShortName = "", LongName = "", NcaaNameSeo = "delaware-st", theSpreadName = "", icon24FileName = "delaware-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "duke", ShortName = "", LongName = "Duke", NcaaNameSeo = "duke", theSpreadName = "Duke", icon24FileName = "duke.24.png" });
                dbSession.Store(new TeamData { TeamCode = "duquesne", ShortName = "", LongName = "", NcaaNameSeo = "duquesne", theSpreadName = "", icon24FileName = "duquesne.24.png" });
                dbSession.Store(new TeamData { TeamCode = "east-carolina", ShortName = "", LongName = "", NcaaNameSeo = "east-carolina", theSpreadName = "", icon24FileName = "east-carolina.24.png" });
                dbSession.Store(new TeamData { TeamCode = "eastern-ill", ShortName = "", LongName = "", NcaaNameSeo = "eastern-ill", theSpreadName = "", icon24FileName = "eastern-ill.24.png" });
                dbSession.Store(new TeamData { TeamCode = "eastern-mich", ShortName = "", LongName = "", NcaaNameSeo = "eastern-mich", theSpreadName = "", icon24FileName = "eastern-mich.24.png" });
                dbSession.Store(new TeamData { TeamCode = "elon", ShortName = "", LongName = "", NcaaNameSeo = "elon", theSpreadName = "", icon24FileName = "elon.24.png" });
                dbSession.Store(new TeamData { TeamCode = "fiu", ShortName = "", LongName = "Florida Intl", NcaaNameSeo = "fiu", theSpreadName = "Florida Intl", icon24FileName = "fiu.24.png" });
                dbSession.Store(new TeamData { TeamCode = "fla-atlantic", ShortName = "", LongName = "Florida Atlantic", NcaaNameSeo = "fla-atlantic", theSpreadName = "Florida Atlantic", icon24FileName = "fla-atlantic.24.png" });
                dbSession.Store(new TeamData { TeamCode = "florida-st", ShortName = "", LongName = "Florida State", NcaaNameSeo = "florida-st", theSpreadName = "Florida State", icon24FileName = "florida-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "florida", ShortName = "", LongName = "", NcaaNameSeo = "florida", theSpreadName = "", icon24FileName = "florida.24.png" });
                dbSession.Store(new TeamData { TeamCode = "fordham", ShortName = "", LongName = "", NcaaNameSeo = "fordham", theSpreadName = "", icon24FileName = "fordham.24.png" });
                dbSession.Store(new TeamData { TeamCode = "fresno-st", ShortName = "", LongName = "", NcaaNameSeo = "fresno-st", theSpreadName = "", icon24FileName = "fresno-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "furman", ShortName = "", LongName = "", NcaaNameSeo = "furman", theSpreadName = "", icon24FileName = "furman.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ga-southern", ShortName = "", LongName = "", NcaaNameSeo = "ga-southern", theSpreadName = "", icon24FileName = "ga-southern.24.png" });
                dbSession.Store(new TeamData { TeamCode = "georgia-st", ShortName = "", LongName = "", NcaaNameSeo = "georgia-st", theSpreadName = "", icon24FileName = "georgia-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "georgia-tech", ShortName = "", LongName = "", NcaaNameSeo = "georgia-tech", theSpreadName = "", icon24FileName = "georgia-tech.24.png" });
                dbSession.Store(new TeamData { TeamCode = "georgia", ShortName = "", LongName = "", NcaaNameSeo = "georgia", theSpreadName = "", icon24FileName = "georgia.24.png" });
                dbSession.Store(new TeamData { TeamCode = "grambling", ShortName = "", LongName = "", NcaaNameSeo = "grambling", theSpreadName = "", icon24FileName = "grambling.24.png" });
                dbSession.Store(new TeamData { TeamCode = "hawaii", ShortName = "", LongName = "Hawaii", NcaaNameSeo = "hawaii", theSpreadName = "Hawaii", icon24FileName = "hawaii.24.png" });
                dbSession.Store(new TeamData { TeamCode = "houston", ShortName = "", LongName = "", NcaaNameSeo = "houston", theSpreadName = "", icon24FileName = "houston.24.png" });
                dbSession.Store(new TeamData { TeamCode = "howard", ShortName = "", LongName = "", NcaaNameSeo = "howard", theSpreadName = "", icon24FileName = "howard.24.png" });
                dbSession.Store(new TeamData { TeamCode = "idaho", ShortName = "", LongName = "", NcaaNameSeo = "idaho", theSpreadName = "", icon24FileName = "idaho.24.png" });
                dbSession.Store(new TeamData { TeamCode = "illinois", ShortName = "", LongName = "Illinois", NcaaNameSeo = "illinois", theSpreadName = "Illinois", icon24FileName = "illinois.24.png" });
                dbSession.Store(new TeamData { TeamCode = "incarnate-word", ShortName = "", LongName = "", NcaaNameSeo = "incarnate-word", theSpreadName = "", icon24FileName = "incarnate-word.24.png" });
                dbSession.Store(new TeamData { TeamCode = "indiana", ShortName = "", LongName = "Indiana", NcaaNameSeo = "indiana", theSpreadName = "Indiana", icon24FileName = "indiana.24.png" });
                dbSession.Store(new TeamData { TeamCode = "iowa-st", ShortName = "", LongName = "", NcaaNameSeo = "iowa-st", theSpreadName = "", icon24FileName = "iowa-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "iowa", ShortName = "", LongName = "Iowa", NcaaNameSeo = "iowa", theSpreadName = "Iowa", icon24FileName = "iowa.24.png" });
                dbSession.Store(new TeamData { TeamCode = "jackson-st", ShortName = "", LongName = "", NcaaNameSeo = "jackson-st", theSpreadName = "", icon24FileName = "jackson-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "james-madison", ShortName = "", LongName = "", NcaaNameSeo = "james-madison", theSpreadName = "", icon24FileName = "james-madison.24.png" });
                dbSession.Store(new TeamData { TeamCode = "kansas-st", ShortName = "", LongName = "", NcaaNameSeo = "kansas-st", theSpreadName = "", icon24FileName = "kansas-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "kansas", ShortName = "", LongName = "", NcaaNameSeo = "kansas", theSpreadName = "", icon24FileName = "kansas.24.png" });
                dbSession.Store(new TeamData { TeamCode = "kennesaw-st", ShortName = "", LongName = "", NcaaNameSeo = "kennesaw-st", theSpreadName = "", icon24FileName = "kennesaw-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "kent-st", ShortName = "", LongName = "Kent", NcaaNameSeo = "kent-st", theSpreadName = "Kent", icon24FileName = "kent-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "kentucky", ShortName = "", LongName = "Kentucky", NcaaNameSeo = "kentucky", theSpreadName = "Kentucky", icon24FileName = "kentucky.24.png" });
                dbSession.Store(new TeamData { TeamCode = "la-monroe", ShortName = "", LongName = "", NcaaNameSeo = "la-monroe", theSpreadName = "", icon24FileName = "la-monroe.24.png" });
                dbSession.Store(new TeamData { TeamCode = "liberty", ShortName = "", LongName = "Liberty", NcaaNameSeo = "liberty", theSpreadName = "Liberty", icon24FileName = "liberty.24.png" });
                dbSession.Store(new TeamData { TeamCode = "louisiana-tech", ShortName = "", LongName = "Louisiana Tech", NcaaNameSeo = "louisiana-tech", theSpreadName = "Louisiana Tech", icon24FileName = "louisiana-tech.24.png" });
                dbSession.Store(new TeamData { TeamCode = "louisiana", ShortName = "", LongName = "", NcaaNameSeo = "louisiana", theSpreadName = "", icon24FileName = "louisiana.24.png" });
                dbSession.Store(new TeamData { TeamCode = "louisville", ShortName = "", LongName = "Louisville", NcaaNameSeo = "louisville", theSpreadName = "Louisville", icon24FileName = "louisville.24.png" });
                dbSession.Store(new TeamData { TeamCode = "lsu", ShortName = "", LongName = "LSU", NcaaNameSeo = "lsu", theSpreadName = "LSU", icon24FileName = "lsu.24.png" });
                dbSession.Store(new TeamData { TeamCode = "marshall", ShortName = "", LongName = "Marshall", NcaaNameSeo = "marshall", theSpreadName = "Marshall", icon24FileName = "marshall.24.png" });
                dbSession.Store(new TeamData { TeamCode = "maryland", ShortName = "", LongName = "Maryland", NcaaNameSeo = "maryland", theSpreadName = "Maryland", icon24FileName = "maryland.24.png" });
                dbSession.Store(new TeamData { TeamCode = "massachusetts", ShortName = "", LongName = "Massachusetts", NcaaNameSeo = "massachusetts", theSpreadName = "Massachusetts", icon24FileName = "massachusetts.24.png" });
                dbSession.Store(new TeamData { TeamCode = "memphis", ShortName = "", LongName = "", NcaaNameSeo = "memphis", theSpreadName = "", icon24FileName = "memphis.24.png" });
                dbSession.Store(new TeamData { TeamCode = "mercer", ShortName = "", LongName = "", NcaaNameSeo = "mercer", theSpreadName = "", icon24FileName = "mercer.24.png" });
                dbSession.Store(new TeamData { TeamCode = "miami-fl", ShortName = "", LongName = "Miami Florida", NcaaNameSeo = "miami-fl", theSpreadName = "Miami Florida", icon24FileName = "miami-fl.24.png" });
                dbSession.Store(new TeamData { TeamCode = "miami-oh", ShortName = "", LongName = "Miami Ohio", NcaaNameSeo = "miami-oh", theSpreadName = "Miami Ohio", icon24FileName = "miami-oh.24.png" });
                dbSession.Store(new TeamData { TeamCode = "michigan-st", ShortName = "", LongName = "Michigan State", NcaaNameSeo = "michigan-st", theSpreadName = "Michigan State", icon24FileName = "michigan-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "michigan", ShortName = "", LongName = "Michigan", NcaaNameSeo = "michigan", theSpreadName = "Michigan", icon24FileName = "michigan.24.png" });
                dbSession.Store(new TeamData { TeamCode = "middle-tenn", ShortName = "", LongName = "Middle Tenn St", NcaaNameSeo = "middle-tenn", theSpreadName = "Middle Tenn St", icon24FileName = "middle-tenn.24.png" });
                dbSession.Store(new TeamData { TeamCode = "minnesota", ShortName = "", LongName = "Minnesota", NcaaNameSeo = "minnesota", theSpreadName = "Minnesota", icon24FileName = "minnesota.24.png" });
                dbSession.Store(new TeamData { TeamCode = "mississippi-st", ShortName = "", LongName = "", NcaaNameSeo = "mississippi-st", theSpreadName = "", icon24FileName = "mississippi-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "missouri-st", ShortName = "", LongName = "", NcaaNameSeo = "missouri-st", theSpreadName = "", icon24FileName = "missouri-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "missouri", ShortName = "", LongName = "", NcaaNameSeo = "missouri", theSpreadName = "", icon24FileName = "missouri.24.png" });
                dbSession.Store(new TeamData { TeamCode = "monmouth", ShortName = "", LongName = "", NcaaNameSeo = "monmouth", theSpreadName = "", icon24FileName = "monmouth.24.png" });
                dbSession.Store(new TeamData { TeamCode = "navy", ShortName = "", LongName = "", NcaaNameSeo = "navy", theSpreadName = "", icon24FileName = "navy.24.png" });
                dbSession.Store(new TeamData { TeamCode = "nc-at", ShortName = "", LongName = "", NcaaNameSeo = "nc-at", theSpreadName = "", icon24FileName = "nc-at.24.png" });
                dbSession.Store(new TeamData { TeamCode = "nebraska", ShortName = "", LongName = "Nebraska", NcaaNameSeo = "nebraska", theSpreadName = "Nebraska", icon24FileName = "nebraska.24.png" });
                dbSession.Store(new TeamData { TeamCode = "nevada", ShortName = "", LongName = "", NcaaNameSeo = "nevada", theSpreadName = "", icon24FileName = "nevada.24.png" });
                dbSession.Store(new TeamData { TeamCode = "new-mexico-st", ShortName = "", LongName = "New Mexico State", NcaaNameSeo = "new-mexico-st", theSpreadName = "New Mexico State", icon24FileName = "new-mexico-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "new-mexico", ShortName = "", LongName = "", NcaaNameSeo = "new-mexico", theSpreadName = "", icon24FileName = "new-mexico.24.png" });
                dbSession.Store(new TeamData { TeamCode = "nicholls-st", ShortName = "", LongName = "", NcaaNameSeo = "nicholls-st", theSpreadName = "", icon24FileName = "nicholls-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "north-carolina-st", ShortName = "", LongName = "", NcaaNameSeo = "north-carolina-st", theSpreadName = "", icon24FileName = "north-carolina-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "north-carolina", ShortName = "", LongName = "North Carolina", NcaaNameSeo = "north-carolina", theSpreadName = "North Carolina", icon24FileName = "north-carolina.24.png" });
                dbSession.Store(new TeamData { TeamCode = "north-texas", ShortName = "", LongName = "North Texas", NcaaNameSeo = "north-texas", theSpreadName = "North Texas", icon24FileName = "north-texas.24.png" });
                dbSession.Store(new TeamData { TeamCode = "northern-ariz", ShortName = "", LongName = "", NcaaNameSeo = "northern-ariz", theSpreadName = "", icon24FileName = "northern-ariz.24.png" });
                dbSession.Store(new TeamData { TeamCode = "northern-ill", ShortName = "", LongName = "Northern Illinois", NcaaNameSeo = "northern-ill", theSpreadName = "Northern Illinois", icon24FileName = "northern-ill.24.png" });
                dbSession.Store(new TeamData { TeamCode = "northwestern-st", ShortName = "", LongName = "", NcaaNameSeo = "northwestern-st", theSpreadName = "", icon24FileName = "northwestern-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "northwestern", ShortName = "", LongName = "Northwestern", NcaaNameSeo = "northwestern", theSpreadName = "Northwestern", icon24FileName = "northwestern.24.png" });
                dbSession.Store(new TeamData { TeamCode = "notre-dame", ShortName = "", LongName = "Notre Dame", NcaaNameSeo = "notre-dame", theSpreadName = "Notre Dame", icon24FileName = "notre-dame.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ohio-st", ShortName = "", LongName = "Ohio State", NcaaNameSeo = "ohio-st", theSpreadName = "Ohio State", icon24FileName = "ohio-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ohio", ShortName = "", LongName = "", NcaaNameSeo = "ohio", theSpreadName = "", icon24FileName = "ohio.24.png" });
                dbSession.Store(new TeamData { TeamCode = "oklahoma-st", ShortName = "", LongName = "", NcaaNameSeo = "oklahoma-st", theSpreadName = "", icon24FileName = "oklahoma-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "oklahoma", ShortName = "", LongName = "Oklahoma", NcaaNameSeo = "oklahoma", theSpreadName = "Oklahoma", icon24FileName = "oklahoma.24.png" });
                dbSession.Store(new TeamData { TeamCode = "old-dominion", ShortName = "", LongName = "Old Dominion", NcaaNameSeo = "old-dominion", theSpreadName = "Old Dominion", icon24FileName = "old-dominion.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ole-miss", ShortName = "", LongName = "Mississippi", NcaaNameSeo = "ole-miss", theSpreadName = "Mississippi", icon24FileName = "ole-miss.24.png" });
                dbSession.Store(new TeamData { TeamCode = "oregon-st", ShortName = "", LongName = "Oregon State", NcaaNameSeo = "oregon-st", theSpreadName = "Oregon State", icon24FileName = "oregon-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "oregon", ShortName = "", LongName = "Oregon", NcaaNameSeo = "oregon", theSpreadName = "Oregon", icon24FileName = "oregon.24.png" });
                dbSession.Store(new TeamData { TeamCode = "penn-st", ShortName = "", LongName = "Penn State", NcaaNameSeo = "penn-st", theSpreadName = "Penn State", icon24FileName = "penn-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "pittsburgh", ShortName = "", LongName = "", NcaaNameSeo = "pittsburgh", theSpreadName = "", icon24FileName = "pittsburgh.24.png" });
                dbSession.Store(new TeamData { TeamCode = "portland-st", ShortName = "", LongName = "", NcaaNameSeo = "portland-st", theSpreadName = "", icon24FileName = "portland-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "prairie-view", ShortName = "", LongName = "", NcaaNameSeo = "prairie-view", theSpreadName = "", icon24FileName = "prairie-view.24.png" });
                dbSession.Store(new TeamData { TeamCode = "purdue", ShortName = "", LongName = "Purdue", NcaaNameSeo = "purdue", theSpreadName = "Purdue", icon24FileName = "purdue.24.png" });
                dbSession.Store(new TeamData { TeamCode = "rice", ShortName = "", LongName = "Rice", NcaaNameSeo = "rice", theSpreadName = "Rice", icon24FileName = "rice.24.png" });
                dbSession.Store(new TeamData { TeamCode = "richmond", ShortName = "", LongName = "", NcaaNameSeo = "richmond", theSpreadName = "", icon24FileName = "richmond.24.png" });
                dbSession.Store(new TeamData { TeamCode = "rutgers", ShortName = "", LongName = "Rutgers", NcaaNameSeo = "rutgers", theSpreadName = "Rutgers", icon24FileName = "rutgers.24.png" });
                dbSession.Store(new TeamData { TeamCode = "san-diego-st", ShortName = "", LongName = "San Diego State", NcaaNameSeo = "san-diego-st", theSpreadName = "San Diego State", icon24FileName = "san-diego-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "san-jose-st", ShortName = "", LongName = "", NcaaNameSeo = "san-jose-st", theSpreadName = "", icon24FileName = "san-jose-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "savannah-st", ShortName = "", LongName = "", NcaaNameSeo = "savannah-st", theSpreadName = "", icon24FileName = "savannah-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "smu", ShortName = "", LongName = "SMU", NcaaNameSeo = "smu", theSpreadName = "SMU", icon24FileName = "smu.24.png" });
                dbSession.Store(new TeamData { TeamCode = "south-ala", ShortName = "", LongName = "South Alabama", NcaaNameSeo = "south-ala", theSpreadName = "South Alabama", icon24FileName = "south-ala.24.png" });
                dbSession.Store(new TeamData { TeamCode = "south-carolina-st", ShortName = "", LongName = "", NcaaNameSeo = "south-carolina-st", theSpreadName = "", icon24FileName = "south-carolina-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "south-carolina", ShortName = "", LongName = "South Carolina", NcaaNameSeo = "south-carolina", theSpreadName = "South Carolina", icon24FileName = "south-carolina.24.png" });
                dbSession.Store(new TeamData { TeamCode = "south-dakota-st", ShortName = "", LongName = "", NcaaNameSeo = "south-dakota-st", theSpreadName = "", icon24FileName = "south-dakota-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "south-dakota", ShortName = "", LongName = "", NcaaNameSeo = "south-dakota", theSpreadName = "", icon24FileName = "south-dakota.24.png" });
                dbSession.Store(new TeamData { TeamCode = "south-fla", ShortName = "", LongName = "", NcaaNameSeo = "south-fla", theSpreadName = "", icon24FileName = "south-fla.24.png" });
                dbSession.Store(new TeamData { TeamCode = "southeast-mo-st", ShortName = "", LongName = "", NcaaNameSeo = "southeast-mo-st", theSpreadName = "", icon24FileName = "southeast-mo-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "southeastern-la", ShortName = "", LongName = "", NcaaNameSeo = "southeastern-la", theSpreadName = "", icon24FileName = "southeastern-la.24.png" });
                dbSession.Store(new TeamData { TeamCode = "southern-california", ShortName = "", LongName = "USC", NcaaNameSeo = "southern-california", theSpreadName = "USC", icon24FileName = "southern-california.24.png" });
                dbSession.Store(new TeamData { TeamCode = "southern-miss", ShortName = "", LongName = "", NcaaNameSeo = "southern-miss", theSpreadName = "", icon24FileName = "southern-miss.24.png" });
                dbSession.Store(new TeamData { TeamCode = "southern-u", ShortName = "", LongName = "", NcaaNameSeo = "southern-u", theSpreadName = "", icon24FileName = "southern-u.24.png" });
                dbSession.Store(new TeamData { TeamCode = "stanford", ShortName = "", LongName = "Stanford", NcaaNameSeo = "stanford", theSpreadName = "Stanford", icon24FileName = "stanford.24.png" });
                dbSession.Store(new TeamData { TeamCode = "stephen-f-austin", ShortName = "", LongName = "", NcaaNameSeo = "stephen-f-austin", theSpreadName = "", icon24FileName = "stephen-f-austin.24.png" });
                dbSession.Store(new TeamData { TeamCode = "stony-brook", ShortName = "", LongName = "", NcaaNameSeo = "stony-brook", theSpreadName = "", icon24FileName = "stony-brook.24.png" });
                dbSession.Store(new TeamData { TeamCode = "syracuse", ShortName = "", LongName = "Syracuse", NcaaNameSeo = "syracuse", theSpreadName = "Syracuse", icon24FileName = "syracuse.24.png" });
                dbSession.Store(new TeamData { TeamCode = "tcu", ShortName = "", LongName = "", NcaaNameSeo = "tcu", theSpreadName = "", icon24FileName = "tcu.24.png" });
                dbSession.Store(new TeamData { TeamCode = "temple", ShortName = "", LongName = "", NcaaNameSeo = "temple", theSpreadName = "", icon24FileName = "temple.24.png" });
                dbSession.Store(new TeamData { TeamCode = "tennessee", ShortName = "", LongName = "Tennessee", NcaaNameSeo = "tennessee", theSpreadName = "Tennessee", icon24FileName = "tennessee.24.png" });
                dbSession.Store(new TeamData { TeamCode = "texas-am", ShortName = "", LongName = "", NcaaNameSeo = "texas-am", theSpreadName = "", icon24FileName = "texas-am.24.png" });
                dbSession.Store(new TeamData { TeamCode = "texas-st", ShortName = "", LongName = "Texas State", NcaaNameSeo = "texas-st", theSpreadName = "Texas State", icon24FileName = "texas-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "texas-tech", ShortName = "", LongName = "Texas Tech", NcaaNameSeo = "texas-tech", theSpreadName = "Texas Tech", icon24FileName = "texas-tech.24.png" });
                dbSession.Store(new TeamData { TeamCode = "texas", ShortName = "", LongName = "Texas", NcaaNameSeo = "texas", theSpreadName = "Texas", icon24FileName = "texas.24.png" });
                dbSession.Store(new TeamData { TeamCode = "toledo", ShortName = "", LongName = "", NcaaNameSeo = "toledo", theSpreadName = "", icon24FileName = "toledo.24.png" });
                dbSession.Store(new TeamData { TeamCode = "troy", ShortName = "", LongName = "Troy", NcaaNameSeo = "troy", theSpreadName = "Troy", icon24FileName = "troy.24.png" });
                dbSession.Store(new TeamData { TeamCode = "tulane", ShortName = "", LongName = "Tulane", NcaaNameSeo = "tulane", theSpreadName = "Tulane", icon24FileName = "tulane.24.png" });
                dbSession.Store(new TeamData { TeamCode = "tulsa", ShortName = "", LongName = "", NcaaNameSeo = "tulsa", theSpreadName = "", icon24FileName = "tulsa.24.png" });
                dbSession.Store(new TeamData { TeamCode = "uab", ShortName = "", LongName = "", NcaaNameSeo = "uab", theSpreadName = "", icon24FileName = "uab.24.png" });
                dbSession.Store(new TeamData { TeamCode = "uc-davis", ShortName = "", LongName = "", NcaaNameSeo = "uc-davis", theSpreadName = "", icon24FileName = "uc-davis.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ucf", ShortName = "", LongName = "Central Florida", NcaaNameSeo = "ucf", theSpreadName = "Central Florida", icon24FileName = "ucf.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ucla", ShortName = "", LongName = "UCLA", NcaaNameSeo = "ucla", theSpreadName = "UCLA", icon24FileName = "ucla.24.png" });
                dbSession.Store(new TeamData { TeamCode = "uconn", ShortName = "", LongName = "Connecticut", NcaaNameSeo = "uconn", theSpreadName = "Connecticut", icon24FileName = "uconn.24.png" });
                dbSession.Store(new TeamData { TeamCode = "unlv", ShortName = "", LongName = "UNLV", NcaaNameSeo = "unlv", theSpreadName = "UNLV", icon24FileName = "unlv.24.png" });
                dbSession.Store(new TeamData { TeamCode = "ut-martin", ShortName = "", LongName = "", NcaaNameSeo = "ut-martin", theSpreadName = "", icon24FileName = "ut-martin.24.png" });
                dbSession.Store(new TeamData { TeamCode = "utah-st", ShortName = "", LongName = "Utah State", NcaaNameSeo = "utah-st", theSpreadName = "Utah State", icon24FileName = "utah-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "utah", ShortName = "", LongName = "", NcaaNameSeo = "utah", theSpreadName = "", icon24FileName = "utah.24.png" });
                dbSession.Store(new TeamData { TeamCode = "utep", ShortName = "", LongName = "", NcaaNameSeo = "utep", theSpreadName = "", icon24FileName = "utep.24.png" });
                dbSession.Store(new TeamData { TeamCode = "utsa", ShortName = "", LongName = "UTSA", NcaaNameSeo = "utsa", theSpreadName = "UTSA", icon24FileName = "utsa.24.png" });
                dbSession.Store(new TeamData { TeamCode = "vanderbilt", ShortName = "", LongName = "Vanderbilt", NcaaNameSeo = "vanderbilt", theSpreadName = "Vanderbilt", icon24FileName = "vanderbilt.24.png" });
                dbSession.Store(new TeamData { TeamCode = "villanova", ShortName = "", LongName = "", NcaaNameSeo = "villanova", theSpreadName = "", icon24FileName = "villanova.24.png" });
                dbSession.Store(new TeamData { TeamCode = "virginia-tech", ShortName = "", LongName = "Virginia Tech", NcaaNameSeo = "virginia-tech", theSpreadName = "Virginia Tech", icon24FileName = "virginia-tech.24.png" });
                dbSession.Store(new TeamData { TeamCode = "virginia", ShortName = "", LongName = "", NcaaNameSeo = "virginia", theSpreadName = "", icon24FileName = "virginia.24.png" });
                dbSession.Store(new TeamData { TeamCode = "vmi", ShortName = "", LongName = "", NcaaNameSeo = "vmi", theSpreadName = "", icon24FileName = "vmi.24.png" });
                dbSession.Store(new TeamData { TeamCode = "wake-forest", ShortName = "", LongName = "Wake Forest", NcaaNameSeo = "wake-forest", theSpreadName = "Wake Forest", icon24FileName = "wake-forest.24.png" });
                dbSession.Store(new TeamData { TeamCode = "washington-st", ShortName = "", LongName = "", NcaaNameSeo = "washington-st", theSpreadName = "", icon24FileName = "washington-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "washington", ShortName = "", LongName = "Washington", NcaaNameSeo = "washington", theSpreadName = "Washington", icon24FileName = "washington.24.png" });
                dbSession.Store(new TeamData { TeamCode = "weber-st", ShortName = "", LongName = "", NcaaNameSeo = "weber-st", theSpreadName = "", icon24FileName = "weber-st.24.png" });
                dbSession.Store(new TeamData { TeamCode = "west-virginia", ShortName = "", LongName = "West Virginia", NcaaNameSeo = "west-virginia", theSpreadName = "West Virginia", icon24FileName = "west-virginia.24.png" });
                dbSession.Store(new TeamData { TeamCode = "western-ky", ShortName = "", LongName = "Western Kentucky", NcaaNameSeo = "western-ky", theSpreadName = "Western Kentucky", icon24FileName = "western-ky.24.png" });
                dbSession.Store(new TeamData { TeamCode = "western-mich", ShortName = "", LongName = "", NcaaNameSeo = "western-mich", theSpreadName = "", icon24FileName = "western-mich.24.png" });
                dbSession.Store(new TeamData { TeamCode = "wisconsin", ShortName = "", LongName = "Wisconsin", NcaaNameSeo = "wisconsin", theSpreadName = "Wisconsin", icon24FileName = "wisconsin.24.png" });
                dbSession.Store(new TeamData { TeamCode = "wyoming", ShortName = "", LongName = "Wyoming", NcaaNameSeo = "wyoming", theSpreadName = "Wyoming", icon24FileName = "wyoming.24.png" });

                var count = dbSession.RequestCount;
                dbSession.SaveChanges();

                return count;
            }
        }

        private int LoadWeeks()
        {
            using (var dbSession = _documentStore.LightweightSession())
            {
                dbSession.Store(new WeekData { WeekNumber = 1 });
                dbSession.Store(new WeekData { WeekNumber = 2 });
                dbSession.Store(new WeekData { WeekNumber = 3 });
                dbSession.Store(new WeekData { WeekNumber = 4 });
                dbSession.Store(new WeekData { WeekNumber = 5 });
                dbSession.Store(new WeekData { WeekNumber = 6 });
                dbSession.Store(new WeekData { WeekNumber = 7 });
                dbSession.Store(new WeekData { WeekNumber = 8 });
                dbSession.Store(new WeekData { WeekNumber = 9 });
                dbSession.Store(new WeekData { WeekNumber = 10 });
                dbSession.Store(new WeekData { WeekNumber = 11 });
                dbSession.Store(new WeekData { WeekNumber = 12 });
                dbSession.Store(new WeekData { WeekNumber = 13 });
                dbSession.Store(new WeekData { WeekNumber = 14 });
                dbSession.Store(new WeekData { WeekNumber = 15 });
                dbSession.SaveChanges();

                return 15;
            }
        }
    }
}
