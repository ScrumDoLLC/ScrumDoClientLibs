using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class ScrumDoHelper
    {
        APIMethods obj = new APIMethods();

        // getProjectsForUser	
        public string[] getProjectsForUser()
        {
            string[] projectUrls = obj.GetUser().projects.ToArray();
            string[] projectsNames = new string[projectUrls.Length];

            for (int count = 0; count < projectUrls.Length; count++)
            {
                string[] IDs = projectUrls[count].Split('/');

                projectsNames[count] = obj.GetProject(Convert.ToInt32(IDs[IDs.Length - 2])).name;
            }
            return projectsNames;
        }

        // getIterationsInProject	
        public string[] getIterationsInProject(int projetID)
        {
            string[] iteratonUrls = obj.GetProject(projetID).iterations.ToArray();
            string[] iterationNames = new string[iteratonUrls.Length];

            for (int count = 0; count < iterationNames.Length; count++)
            {
                string[] IDs = iteratonUrls[count].Split('/');

                iterationNames[count] = obj.GetIteration(Convert.ToInt32(IDs[IDs.Length - 2])).name;
            }
            return iterationNames;
        }

        // getStoriesInIteration	
        public string[] getStoriesInIteration(int iterationID)
        {
            string[] storyUrls = obj.GetIteration(iterationID).stories.ToArray();
            string[] storySummary = new string[storyUrls.Length];

            for (int count = 0; count < storyUrls.Length; count++)
            {
                string[] IDs = storyUrls[count].Split('/');

                storySummary[count] = obj.GetStory(Convert.ToInt32(IDs[IDs.Length - 2])).summary;
            }
            return storySummary;
        }

        // getEpicsInProject
        public string[] getEpicsInProject(int projectID)
        {
            string[] epicUrls = obj.GetProject(projectID).epics.ToArray();
            string[] epicSummary = new string[epicUrls.Length];

            for (int count = 0; count < epicUrls.Length; count++)
            {
                string[] IDs = epicUrls[count].Split('/');

                epicSummary[count] = obj.GetEpic(Convert.ToInt32(IDs[IDs.Length - 2])).summary;
            }
            return epicSummary;
        }
        // getEpicsAndStoriesInEpic
        // getTeamsForUser	
        // getTasksAndStoriesForUser	
        // getStoriesForUser	
        // getTasksForStory
        // getCommentsOnStory	
        // getOrganizationsForUser
        // getTeamsForUser
        // assignUserToStory
        // assignUserToTask	
        // markStoryStatus	
        // addStoryToEpic	
        // addTaskToStory	
        // assignStoryToIteration	
        // addCommentToStory	
        // addUserToTeam
    }
}