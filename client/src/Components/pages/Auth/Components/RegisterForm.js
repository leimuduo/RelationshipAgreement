import React from 'react'
import { Form, Input, Button } from 'antd';
import { UserOutlined, LockOutlined, MailOutlined } from '@ant-design/icons';
import { useRouteHandler } from '../../../../util/hooks/route';
import { routes } from '../../../routes/routes';

export const RegisterForm = () => {
  const handleGoTo = useRouteHandler();
  const onFinish = (values) => {
    console.log('Received values of form: ', values);
  };

  return (
    <Form
      className="register-form"
      initialValues={{ remember: false }}
      onFinish={onFinish}
    >
      <Form.Item
        name="firstname"
        rules={[{ required: true, message: 'Please input your first name!' }]}
      >
        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="First name" />
      </Form.Item>
      <Form.Item
        name="lastname"
        rules={[{ required: true, message: 'Please input your last name!' }]}
      >
        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Last name" />
      </Form.Item>
      <Form.Item
        name="email"
        rules={[{ required: true, message: 'Please input your email!' }]}
      >
        <Input prefix={<MailOutlined className="site-form-item-icon" />} placeholder="Email" />
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
      <Form.Item
        name="confirmPassword"
        rules={[{ required: true, message: 'Please confirm your Password!' }]}
      >
        <Input
          prefix={<LockOutlined className="site-form-item-icon" />}
          type="password"
          placeholder="Confirm password"
        />
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" className="register-form-button">
          Sign up
        </Button>
        <p>Already have account? <Button type='link' onClick={handleGoTo(routes.visitor.login)}>Log in</Button></p>
      </Form.Item>
    </Form>
  )
}
