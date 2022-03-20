select * from autorizaciones where aut_periodo = '012020' and AUT_cuit = '30675346506'
select * from facturaciones where fac_periodo = '012020' and fac_cuit = '30675346506'
select * from liquidaciones where liq_periodo_f = '012020' and liq_cuit_f = '30675346506' order by LIQ_NUMEROLIQUIDACION
select * from debitos where deb_liquidacion in (92992,94540,94543,92995)
select * from ANEXO_LIQUIDACIONES where ANX_NUMLIQ in (92992,94540,94543,92995)



begin transaction
	update autorizaciones set aut_saldo = aut_importe where aut_periodo = '012020' and AUT_ESTNUM = 5006
	delete from liquidaciones where liq_periodo_f = '012020' and liq_cuit_f = '30675346506'
	delete from debitos where deb_liquidacion in (92992,94540,94543,92995)
	delete from ANEXO_LIQUIDACIONES where ANX_NUMLIQ in (92992,94540,94543,92995)
commit transaction