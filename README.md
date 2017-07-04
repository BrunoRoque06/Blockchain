# Blockchain

A simple implementation of a blockchain.

Four main classes:
* __Block__, data class, only properties;
* __BlockFactory__, class that generates blocks;
* __HashEstimator__, responsible for the estimation of hashes;
* __Chain__, contains the blockchain.

Right now, it's not possible to add "invalid" blocks to the chain.