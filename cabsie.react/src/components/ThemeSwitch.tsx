import React from 'react';
import { useThemeContext } from '../contexts/ThemeContext';
import { Switch } from '@material-ui/core';

const ThemeSwitch = () => {
  const themeContext = useThemeContext();
  return <Switch onChange={themeContext.toggleTheme} />;
};

export default ThemeSwitch;
