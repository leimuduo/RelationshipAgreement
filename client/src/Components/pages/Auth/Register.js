import React from 'react';
import { Page } from '../../shared/layout/Page';
import { Button } from 'antd';
import { useHistory } from 'react-router-dom';
import { RegisterForm } from './Components/RegisterForm';

export const Register = () => {
  const history = useHistory();

  return (
    <Page>
      <Button type='link' onClick={history.goBack}>{`<`}</Button>
      <h1>Create Account</h1>
      <RegisterForm />
    </Page>
  )
}
