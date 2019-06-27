import React from 'react';
import { Router } from 'react-router-dom';
import * as theme from '../../contexts/ThemeContext';
import AppLayout from './AppLayout';
import { createBrowserHistory } from 'history';

const history = createBrowserHistory();

const App = () => {
  return (
    <theme.Provider>
      <Router history={history}>
        <AppLayout />
      </Router>
    </theme.Provider>
  );
};

export default App;
