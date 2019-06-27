import React from 'react';
import { Container } from '@material-ui/core';
import ProTip from '../ProTip';
import SignIn from '../form/SignIn';

const MainPage = () => {
  return (
    <Container maxWidth="sm">
      <ProTip />
      <SignIn />
    </Container>
  );
};

export default MainPage;
