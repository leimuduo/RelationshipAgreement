import React from 'react'
import {
  BrowserRouter as Router,
} from "react-router-dom";
import { UserRoutes } from './routes/UserRoutes'
import { VisitorRoutes } from './routes/VisitorRoutes'
import 'antd/dist/antd.css'

export const App = () => {
  const isLoggedIn = false;
  return (
    <Router>
      <div className="App">
        {
          isLoggedIn ?
            <UserRoutes /> :
            <VisitorRoutes />
        }
      </div>
    </Router>
  );
}
