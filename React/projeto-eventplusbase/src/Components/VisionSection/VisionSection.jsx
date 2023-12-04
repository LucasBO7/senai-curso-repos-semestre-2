import React from 'react';
import './VisionSection.css'
import Title from '../Title/Title';

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className="vision__box">
            <Title
                titleText={"Visão"}
                color="white"
                additionalClass='vision__title'

            />
            <p className='vision__text'>Lorem ipsum dolor sit amet 
                 adipisicing elit. Iste neque ad, 
                 ducimus rerum, nesciunt aspernatur nostrum 
                 animi molestiae distinctio, vero mollitia 
                 et? Nobis quo velit blanditiis! Quam tenetur
                  sequi temporibus.</p>
            </div>
        </section>
    );
};

export default VisionSection;