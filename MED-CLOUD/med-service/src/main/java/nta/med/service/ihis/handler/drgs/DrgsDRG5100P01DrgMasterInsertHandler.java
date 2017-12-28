package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg4010;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg4010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class DrgsDRG5100P01DrgMasterInsertHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertRequest, DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01DrgMasterInsertHandler.class);
	
	@Resource
	private Drg4010Repository drg4010Repository;

	@Override
	public DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertRequest request) throws Exception {
		DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertResponse.newBuilder();
		Double drgBunho = CommonUtils.parseDouble(request.getIDrgBunho());
		Double fk = CommonUtils.parseDouble(request.getIFk());
		Date jubsuDate = DateUtil.toDate(request.getIJubsuDate(), DateUtil.PATTERN_YYMMDD);
		Double result = drgMasterInsert(getHospitalCode(vertx, sessionId), jubsuDate, drgBunho, request.getIDataDubun(),
				request.getIInOutGubun(), request.getIBunho(), fk);

		if(!result.equals(-1D)){
			response.setResult(true);
		}
		return response.build();
	}
	
	/**
	 * Migrate PROCEDURE DRG_MASTER_INSERT to java
	 * @param hospCode
	 * @param jubsuDate
	 * @param drgBunho
	 * @param dataDubun
	 * @param inOutGubun
	 * @param bunho
	 * @param fk
	 * @return
	 */
	public Double drgMasterInsert(String hospCode, Date jubsuDate, 
			Double drgBunho, String dataDubun, String inOutGubun, String bunho,
			Double fk){
		try{
			Double outPk = null;
			
			Drg4010 drg4010 = new Drg4010();
			drg4010.setSysId("IF");
			drg4010.setSysDate(new Date());
			drg4010.setUpdId(null);
			drg4010.setUpdDate(null);
			drg4010.setHospCode(hospCode);
			
			drg4010.setJubsuDate(jubsuDate);
			drg4010.setDrgBunho(drgBunho);
			
			drg4010.setDataDubun(dataDubun);
			drg4010.setInOutGubun(inOutGubun);
			drg4010.setBunho(bunho);
			
			if(drg4010.getInOutGubun().equals("O")){
				drg4010.setFkout1001(fk);
			}else{
				drg4010.setFkinp1001(fk);
			}
			
			drg4010.setIfSendFlag("N");
			outPk = drg4010IUD("I", drg4010);
			return outPk;
		}catch (Exception e) {
			LOG.error(e.getMessage(), e);
			return -1D;
		}
	}
	
	/**
	 * Migrate procedure DRG4010_IUD to java
	 * @param iudGubun
	 * @param inDrg4010
	 * @return
	 */
	public Double drg4010IUD(String iudGubun, Drg4010 inDrg4010){
		try{
			Double pk = inDrg4010.getPkdrg4010();
			Double seq;
			String seqKey;
			if (iudGubun.equals("D")){
				if(!drg4010Repository.deleteDrg4010(inDrg4010.getHospCode(), inDrg4010.getPkdrg4010())){
					return -1D;
				}
			} else if (iudGubun.equals("U-")){
				if(!drg4010Repository.deleteDrg4010(inDrg4010.getHospCode(), inDrg4010.getPkdrg4010())){
					return -1D;
				}
				return insertDrg4010(inDrg4010);
			} else if(iudGubun.equals("IR")){
				return insertDrg4010(inDrg4010);
			} else if(iudGubun.equals("I")){
				pk = drg4010Repository.getDrg4010Seq("DRG4010_SEQ").doubleValue();
				seqKey = inDrg4010.getHospCode() + DateUtil.toString(inDrg4010.getJubsuDate(), DateUtil.PATTERN_YYMMDD_BLANK) + StringUtils.leftPad(String.format("%.0f",inDrg4010.getDrgBunho()), 10, "0");
				seq = drg4010Repository.getMaxSeq(inDrg4010.getHospCode(), seqKey);
				
				inDrg4010.setPkdrg4010(pk);
				inDrg4010.setSeq(seq);
				
				return insertDrg4010(inDrg4010);
			} else if(iudGubun.equals("UF")){
				if(!drg4010Repository.updateDrg4010(inDrg4010.getUpdDate(), inDrg4010.getUpdId(), inDrg4010.getIfSendFlag(), inDrg4010.getHospCode(), inDrg4010.getPkdrg4010())){
					return -1D;
				}
			}
			return pk;
		}catch (Exception e) {
			LOG.error(e.getMessage(), e);
			return -1D;
		}
	}
	
	public Double insertDrg4010(Drg4010 inDrg4010){
		try {
			Drg4010 drg4010 = new Drg4010();
			drg4010.setSysId(inDrg4010.getSysId());
			drg4010.setSysDate(inDrg4010.getSysDate());
			drg4010.setUpdId(inDrg4010.getUpdId());
			drg4010.setUpdDate(inDrg4010.getUpdDate());
			drg4010.setHospCode(inDrg4010.getHospCode());
			drg4010.setPkdrg4010(inDrg4010.getPkdrg4010());
			drg4010.setJubsuDate(inDrg4010.getJubsuDate());
			drg4010.setDrgBunho(inDrg4010.getDrgBunho());
			drg4010.setSeq(inDrg4010.getSeq());
			drg4010.setDataDubun(inDrg4010.getDataDubun());
			drg4010.setInOutGubun(inDrg4010.getInOutGubun());
			drg4010.setBunho(inDrg4010.getBunho());
			drg4010.setFkout1001(inDrg4010.getFkout1001());
			drg4010.setFkinp1001(inDrg4010.getFkinp1001());
			drg4010.setIfSendFlag(inDrg4010.getIfSendFlag());
			
			drg4010Repository.save(drg4010);
			return inDrg4010.getPkdrg4010();
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
			return -1D;
		}
	}
}
