import { createMuiTheme } from '@material-ui/core/styles';
import { ThemeOptions, Theme } from '@material-ui/core/styles/createMuiTheme';
import deepOrange from '@material-ui/core/colors/deepOrange';
import amber from '@material-ui/core/colors/amber';
import mergeStateRight from '../utils/mergeStateRight';

const fontWeightThin = 100;

const commonTheme: ThemeOptions = {
  typography: {
    fontFamily: [
      '-apple-system',
      'BlinkMacSystemFont',
      '"Segoe UI"',
      'Roboto',
      '"Helvetica Neue"',
      'Arial',
      'sans-serif',
      '"Apple Color Emoji"',
      '"Segoe UI Emoji"',
      '"Segoe UI Symbol"'
    ].join(','),
    h1: {
      fontWeight: fontWeightThin
    },
    h2: {
      fontWeight: fontWeightThin
    },
    h3: {
      fontWeight: fontWeightThin
    },
    h4: {
      fontWeight: fontWeightThin
    }
  },
  palette: {
    primary: {
      main: deepOrange[500]
    },
    secondary: {
      main: amber[500]
    }
  },
  spacing: 8
};

const overrides = (theme: ThemeOptions): ThemeOptions => ({});

const createTheme = (override: ThemeOptions): Theme => {
  const theme = createMuiTheme(mergeStateRight(commonTheme, override));
  return mergeStateRight(theme, overrides(theme));
};

export default createTheme;
