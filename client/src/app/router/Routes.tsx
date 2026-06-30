import { createBrowserRouter, Navigate } from 'react-router'
import App from '../layout/App'
import HomePage from '../../features/home/HomePage'
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard'
import ActivityForm from '../../features/activities/form/ActivityForm'
import ActivityDetailsPage from '../../features/activities/details/ActivityDetailsPage'
import Counter from '../../features/counter/Counter'
import TestErrors from '../../features/errors/TestErrors'
import NotFound from '../../features/errors/NotFound'
import ServerError from '../../features/errors/ServerError'

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      { path: '', element: <HomePage /> },
      { path: 'activities', element: <ActivityDashboard key="activities" /> },
      {
        path: 'activities/:id',
        element: <ActivityDetailsPage key="activitiesId" />,
      },
      { path: 'createActivity', element: <ActivityForm key="create" /> },
      { path: 'manage/:id', element: <ActivityForm key="manage" /> },
      { path: 'counter', element: <Counter key="counter" /> },
      { path: 'errors', element: <TestErrors key="testErrors" /> },
      { path: 'not-found', element: <NotFound key="notFound" /> },
      { path: 'server-error', element: <ServerError key="serverError" /> },
      { path: '*', element: <Navigate replace to="/not-Found" /> },
    ],
  },
])
