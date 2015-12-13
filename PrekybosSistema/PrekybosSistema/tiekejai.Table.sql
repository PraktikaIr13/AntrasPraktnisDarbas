CREATE TABLE [dbo].[Tiekejai] (
    [tiekejo_kodas]       INT      NOT NULL,
    [tiekejo_pavadinimas] TEXT     NULL,
    [sutartis_pasirasyta] DATE NULL,
    [sutartis_pasibaigia] DATE NULL,
    PRIMARY KEY CLUSTERED ([tiekejo_kodas] ASC)
);

