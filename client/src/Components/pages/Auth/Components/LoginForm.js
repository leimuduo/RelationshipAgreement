import React from 'react'
import { Form, Input, Button, Checkbox } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { useRouteHandler } from '../../../../util/hooks/route';
import { routes } from '../../../routes/routes';

export const LoginForm = () => {
  const handleGoTo = useRouteHandler();
  const onFinish = (values) => {
    console.log('Received values of form: ', values);
  };

  return (
    <Form
      className="ra-login-form"
      initialValues={{ remember: false }}
      onFinish={onFinish}
    >
      <Form.Item
        name="username"
        rules={[{ required: true, message: 'Please input your Username!' }]}
      >
        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
      </Form.Item>
      <Form.Item
        name="password"
        rules={[{ required: true, message: 'Please input your Password!' }]}
      >
        <Input
          prefix={<LockOutlined className="site-form-item-icon" />}
          type="password"
          placeholder="Password"
        />
      </Form.Item>
      <Form.Item>
        <Form.Item name="remember" valuePropName="checked" noStyle>
          <Checkbox>Remember me</Checkbox>
        </Form.Item>

        <Button type='link' onClick={handleGoTo(routes.visitor.landing)}>
          Forgot password
        </Button>
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" className="login-form-button">
          Log in
        </Button>
        <p>Don't have account? <Button type='link' onClick={handleGoTo(routes.visitor.register)}>Sign up</Button></p>
      </Form.Item>
    </Form>
  )
}
