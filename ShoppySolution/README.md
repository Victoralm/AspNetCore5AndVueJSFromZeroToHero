# Shoppy project

E-Commerce Web Site with MySQL & Entity Framework

## Shoppy

App (FrontEnd) layer, uses the [Services](Services/) layer classes to read
and write data from the Persistence ([DAL](DAL/)) layer.

## Interfaces

The interface files for the [Services](Services/) classes.

## Services

Also known as Application layer, does the mediation between the App ([Shoppy](Shoppy/))
and the Persistence ([DAL](DAL/)) layers.

## Domain Objects

Defines objects to be at the Domain layer, used as intermediate objects before
we transfer the real ones to the actions on the Persistance ([DAL](DAL/))
layer.

## Data Access Layer

Also know as Persistant layer, is used to persist the data passed from the Application
([Services](Services/)) layer.

## Business Layer

Class files that implement the [BL Interfaces](Interfaces/) and does the
auto-mapping between the [Domain Objects](Entities/) and the [POCO
classes](DAL/MySqlDbContext/).

## Shoppy Html Helper

Helper classes designed to create custom asp tags
