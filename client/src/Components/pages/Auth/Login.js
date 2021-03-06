import React from 'react';
import { Page } from '../../shared/layout/Page';
import { Button } from 'antd';
import { useHistory } from 'react-router-dom';
import { LoginForm } from './Components/LoginForm';

export const Login = () => {
  const history = useHistory();

  return (
    <Page>
      <Button type='link' onClick={history.goBack}>{`<`}</Button>
      <h1>Welcome Back!</h1>
      <LoginForm />
    </Page>
  )
}
