import React from 'react';

const MainContent = ({children}) => {
    return (
        <main className='main-content'>
            {children}
        </main>
    );
};

export default MainContent;