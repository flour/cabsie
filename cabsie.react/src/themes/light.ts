import { ThemeOptions } from '@material-ui/core/styles/createMuiTheme';
import deepOrange from '@material-ui/core/colors/deepOrange';
import amber from '@material-ui/core/colors/amber';
import createTheme from './createTheme';

const lightTheme: ThemeOptions = {
  palette: {
    type: 'light',
    primary: {
      main: deepOrange[500]
    },
    secondary: {
      main: amber[500]
    },
    background: {
      default: deepOrange[50],
      paper: '#eceff1'
    },
    contrastThreshold: 2.8
  }
};

export default createTheme(lightTheme);
