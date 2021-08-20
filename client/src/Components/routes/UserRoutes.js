import React from 'react'
import {
  Switch,
  Route,
} from "react-router-dom";
import { FamilyDashboard } from '../pages/FamilyDashboard/FamilyDashboard';
import { UserDashboard } from '../pages/UserDashboard/UserDashboard';
import { routes } from './routes';

export const UserRoutes = () => {
  return (
    <Switch>
      <Route path={routes.user.family.dashboard}>
        <FamilyDashboard />
      </Route>
      <Route path={routes.user.dashboard}>
        <UserDashboard />
      </Route>
    </Switch>
  )
}
