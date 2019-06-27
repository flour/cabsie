import { ThemeOptions } from '@material-ui/core/styles/createMuiTheme';
import deepOrange from '@material-ui/core/colors/deepOrange';
import amber from '@material-ui/core/colors/amber';
import createTheme from './createTheme';

const darkTheme: ThemeOptions = {
  palette: {
    type: 'dark',
    primary: {
      main: deepOrange[900],
      contrastText: '#fafafa',
    },
    secondary: {
      main: amber[900],
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
