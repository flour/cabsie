import { ThemeOptions } from '@material-ui/core/styles/createMuiTheme';
import deepOrange from '@material-ui/core/colors/deepOrange';
import amber from '@material-ui/core/colors/amber';
import createTheme from './createTheme';

const darkTheme: ThemeOptions = {
  palette: {
    type: 'dark',
    primary: {
      dark: deepOrange[900],
      main: deepOrange[900],
      light: deepOrange[700],
      contrastText: '#fafafa',
    },
    secondary: {
      dark: amber[900],
      main: amber[900],
      light: amber[700],
      contrastText: '#fafafa',
    },
    background: {
      default: '#181820',
      paper: '#2B2B33'
    },
    contrastThreshold: 2.8
  }
};

export default createTheme(darkTheme);
