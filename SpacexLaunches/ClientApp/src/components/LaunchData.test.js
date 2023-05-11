import React from 'react';
import { render, screen, act } from '@testing-library/react';
import LaunchData from './LaunchData';

global.fetch = (() =>
    Promise.resolve({}));

describe("LaunchData Component error", () => {
    it('Show something bad happen when problem in converting json...', async () => {
        await act(async () => render(<LaunchData />));
        expect(screen.getByText("Something Bad happened."));
    })
})
