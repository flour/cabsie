import light from './light';
import dark from './dark';
import { Theme } from '@material-ui/core/styles/createMuiTheme';

export interface IThemes {
  light: Theme;
  dark: Theme;
}

const themes: IThemes = {
  light,
  dark
};

export default themes;
