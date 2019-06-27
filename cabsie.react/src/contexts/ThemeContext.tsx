import React from 'react';
import themes from '../themes';
import { Theme } from '@material-ui/core';

type ThemeState = {
  theme: Theme;
  toggleTheme: () => void;
};

const initialState: ThemeState = {
  theme: themes.light,
  toggleTheme: () => {}
};

interface IThemeContext {
  theme: Theme;
  toggleTheme: () => void;
}

export const ThemeContextFactory = React.createContext<IThemeContext>({
  theme: themes.light,
  toggleTheme: () => {}
});

export function Provider({ children }: { children: React.ReactNode }): any {
  const [state, setState] = React.useState(initialState);

  const toggleTheme = (): void => {
    const newtheme =
      state.theme.palette.type === 'light' ? themes.dark : themes.light;
    setState({
      ...state,
      ...{ theme: newtheme }
    });
  };

  const context: IThemeContext = {
    ...state,
    toggleTheme
  };

  return (
    <ThemeContextFactory.Provider value={context}>
      {children}
    </ThemeContextFactory.Provider>
  );
}

export const useThemeContext = (): IThemeContext =>
  React.useContext(ThemeContextFactory);
