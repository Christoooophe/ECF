﻿describe('scénario ajout d\'un participant', () => {
    beforeEach(() => {
        cy.visit('http://localhost:5157/')
        cy.get('[data-test="participantLink"]').click()
        cy.url().should('include', '/Participants')
        cy.get('[data-test="createParticipant"]').click()
        cy.url().should('include', '/Participants/Create')
    })
    it('création d\'un participant', () => {
        cy.get('[data-test="inputParticipantName"]').type('Dupond')
        cy.get('[data-test="inputParticipantFirstname"]').type('Jean')
        cy.get('[data-test="inputParticipantAge"]').type('40')
        cy.get('[data-test="buttonCreateParticipant"]').click()
        cy.url().should('include', '/Participants')
        cy.get('tbody tr').last().within(() => {
            cy.get('[data-test="detailsButtonParticipant"]').click()
        })
        cy.url().should('include', 'Participants/Details')
        cy.get('[data-test="nameDetailPage"]').should('contain', 'Dupond')
        cy.get('[data-test="firstnameDetailPage"]').should('contain', 'Jean')
        cy.get('[data-test="ageDetailPage"]').should('contain', '40')
    })
    it('création d\'un participant avec âge en dessous de 16 ans', () => {
        cy.get('[data-test="inputParticipantName"]').type('Dupond')
        cy.get('[data-test="inputParticipantFirstname"]').type('Jean')
        cy.get('[data-test="inputParticipantAge"]').type('5')
        cy.get('[data-test="buttonCreateParticipant"]').click()
        cy.get('#Age-error').should('contain', 'L\'age doit être compris entre 16 et 99 ans')
    })
    it('création d\'un participant avec âge au dessus de 99 ans', () => {
        cy.get('[data-test="inputParticipantName"]').type('Dupond')
        cy.get('[data-test="inputParticipantFirstname"]').type('Jean')
        cy.get('[data-test="inputParticipantAge"]').type('235')
        cy.get('[data-test="buttonCreateParticipant"]').click()
        cy.get('#Age-error').should('contain', 'L\'age doit être compris entre 16 et 99 ans')
    })
})