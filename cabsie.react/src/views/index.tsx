import React from 'react';
import { MuiThemeProvider, makeStyles } from '@material-ui/core/styles';
import { CssBaseline } from '@material-ui/core';
import MenuBar from '../components/MenuBar';
import MainPage from '../components/MainPage';
import * as theme from '../contexts/ThemeContext';

const useStyles = makeStyles(theme => ({
  root: {
    background: theme.palette.background.default
  }
}));

const MainContainer = () => {
  const themeContext = theme.useThemeContext();
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <MuiThemeProvider theme={themeContext.theme}>
        <CssBaseline />
        <MenuBar />
        <MainPage />
      </MuiThemeProvider>
    </div>
  );
};

export default MainContainer;
