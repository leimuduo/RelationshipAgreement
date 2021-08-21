import React from 'react';

export const Page = ({children, className}) => {
  return (
    <div className={`page ${className}`}>
      {children}
    </div>
  )
}
