import React from 'react'
import { useWindowOrientation } from '../../../util/hooks/window'
import { Button } from 'antd';
import { routes } from '../../routes/routes';
import { useRouteHandler } from '../../../util/hooks/route.js';
import { Page } from '../../shared/layout/Page';

const AppName = () => {
  return <h2 className='warning'>Relationship Agreement</h2>
}
const AppTitle = () => {
  return <h1>Plan Family Events And Activities Together</h1>
}

const AppDescription = () => {
  return <p>We provide a token system for your family members</p>
}

const Actions = () => {
  const handleGoTo = useRouteHandler()

  return <div id='actions'>
    <Button onClick={handleGoTo(routes.visitor.login)}>Login</Button>
    <p>Don't have account? <Button type='link' onClick={handleGoTo(routes.visitor.register)}>Sign up</Button></p>
  </div>
}

const DesktopLandingPage = () => {
  return (
    <Page className='landing horizontal'>
      <div>
        <AppName />
        <AppTitle />
        <AppDescription />
        <Actions />
      </div>
    </Page>
  )
}

const MobileLandingPage = () => {
  return (
    <Page className='landing vertical'>
      <AppName />
      <AppTitle />
      <Actions />
    </Page>
  )
}

export const LandingPage = () => {
  const isHorizontal = useWindowOrientation();
  if (isHorizontal) return <DesktopLandingPage />
  else return <MobileLandingPage />
}
