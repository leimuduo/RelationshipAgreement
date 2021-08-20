import React from 'react'
import {
  Switch,
  Route,
} from "react-router-dom";
import { Login } from '../pages/Auth/Login';
import { routes } from './routes';

export const VisitorRoutes = () => {
  return (
    <Switch>
      <Route path={routes.visitor.login}>
        <Login />
      </Route>
    </Switch>
  )
}
