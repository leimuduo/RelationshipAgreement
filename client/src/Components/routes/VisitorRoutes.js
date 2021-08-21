import React from 'react'
import {
  Switch,
  Route,
} from "react-router-dom";
import { Login } from '../pages/Auth/Login';
import { Register } from '../pages/Auth/Register';
import { LandingPage } from '../pages/Landing/LandingPage';
import { routes } from './routes';

export const VisitorRoutes = () => {
  return (
    <Switch>
      <Route path={routes.visitor.landing}>
        <LandingPage />
      </Route>
      <Route path={routes.visitor.login}>
        <Login />
      </Route>
      <Route path={routes.visitor.register}>
        <Register />
      </Route>
      <Route path={routes.root}>
        <LandingPage />
      </Route>
    </Switch>
  )
}
