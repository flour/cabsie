import React from 'react';
import { AppBar } from '@material-ui/core';
import ThemeSwitch from '../ThemeSwitch';

const MenuBar = () => {
  return (
    <AppBar position="fixed">
      <ThemeSwitch />
    </AppBar>
  );
};

export default MenuBar;
