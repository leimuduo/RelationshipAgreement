import React from 'react'
import {
  BrowserRouter as Router,
} from "react-router-dom";
import { UserRoutes } from './routes/UserRoutes'
import { VisitorRoutes } from './routes/VisitorRoutes'

export const App = () => {
  const isLoggedIn = true;
  return (
    <Router>
      <div className="App">
        Relationship agreement
      </div>
      {
        isLoggedIn ?
          <UserRoutes /> :
          <VisitorRoutes />
      }
    </Router>
  );
}
