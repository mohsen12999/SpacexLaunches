# SpaceX Launches

- an application for read data from SpaceX API and show in webpage.

## Tech

- Dot Net Core 7
- ReactJS

## Requirements

1. Use the [SpaceX API](https://docs.spacexdata.com/) to retrieve the details of all past and upcoming launches. You can use any programming language or framework of your choice, but we recommend using .NET and React.
2. Implement a React application that displays the details of all past and upcoming launches retrieved from the SpaceX API.
3. Add a feature to your React application that allows the user to click on a launch and view the details of that specific launch.
4. Implement an API endpoint using .NET that retrieves the details of a specific launch by its ID.
5. Add a button or link to your React application that, when clicked, calls your API endpoint and displays the details of the selected launch.
6. Implement automated tests to ensure that the API endpoint returns the expected results for valid inputs and handles invalid inputs gracefully.

## Deliverables

1. The source code for your React application and API endpoint, and automated tests.You can send code to us or create a git repository on github and upload code there.
2. Documentation that explains how to build and run your React application and API endpoint.

## Note

- You are free to use any additional third-party libraries or frameworks that you think will be helpful for completing the task.
- The scope of this task is intentionally kept small to allow you to complete it within a reasonable amount of time. However, feel free to add any additional features or 
functionality that you think will showcase your skills in REST API integration using .NET and React.
- We will be evaluating your code for quality, so please ensure that you adhere to industry best practices for software development.
- This task is intended to be a representation of the kind of work you would be doing if you were hired as a Software Engineer for our product team.

## How it makes

- it's made from `.net core web application with ReactJs` template in visual studio. that was a simple single page application with .net core controller and ReactJs for front-end side.
- at the first, I used SpaceX Api v3. but after saw a problems from data and data type inconsistency, I changed it to SpaceX Api v5. it's simpler and has a better reliability. also, make a simpler model for avoiding errors in converting.

### Back-end

- it was very simple. a controller and a model.
  - `SpacexController` is our controller and for get data from server and convert it to our model. that has two methods.
    - `GetAllLaunchAsync`: for getting all launch data from API.
    - `GetLaunchByIdAsync`: for getting one launch data from API base on id.
  - `Launch` is our model for converting API data to our useful data.

### Front-end

- in front-end we have two main component:
  - `AllLaunches` component: that show when app running and in our first page. that show all launch data in a list.
  - `LaunchData` component: that show data base on the given id.
