package nta.med.service.ihis.handler.cpls;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.cpl.Cpl2090;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.dao.medi.cpl.Cpl2007Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.cpl.Cpl2090Repository;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.dao.medi.ocs.Ocs5010Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectInOutGubunListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02SaveRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL3020U02SaveHandler extends ScreenHandler<CplsServiceProto.CPL3020U02SaveRequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	@Resource
	private Cpl3010Repository cpl3010Repository;
	
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Resource
	private Ocs5010Repository ocs5010Repository;
	
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Resource
	private Cpl2007Repository cpl2007Repository;
	
	@Resource
	private Cpl2090Repository cpl2090Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U02SaveRequest request)
			throws Exception  {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	response = savePerformer(request, hospCode);
    	return response.build();
	}
	private SystemServiceProto.UpdateResponse.Builder savePerformer(CplsServiceProto.CPL3020U02SaveRequest request, String hospCode){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date sysDate = DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD);
		String sysTime = DateUtil.getCurrentHH24MI();
		//1.
		List<CplsModelProto.CPL3020U00GrdResultListItemInfo> listGrdResult = request.getGrdResultItemInfoList();
		if(!CollectionUtils.isEmpty(listGrdResult)){
			for (CplsModelProto.CPL3020U00GrdResultListItemInfo grdResult : listGrdResult){
				if(grdResult.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					Double pkcpl3020 = CommonUtils.parseDouble(grdResult.getPkcpl3020());
					if("Y".equalsIgnoreCase(grdResult.getConfirmYn())){
						cpl3020Repository.updateCPL3020U02ExecuteConfirmY(request.getUserId(), sysDate, grdResult.getGumsaja(), hospCode, pkcpl3020);
					}else if("N".equalsIgnoreCase(grdResult.getConfirmYn())){
						cpl3020Repository.updateCPL3020U02ExecuteConfirmN(request.getUserId(), sysDate, hospCode, pkcpl3020);
					}
					//
					String tInOutGubun = "";
                    Double tFkocs = 0D;
                    
					List<CPL3020U00SelectInOutGubunListItemInfo> listSelectInOutGubun = cpl2010Repository.getCPL3020U00SelectInOutGubun(hospCode, grdResult.getFkcpl2010());
	            	if(!CollectionUtils.isEmpty(listSelectInOutGubun)){
	            		tInOutGubun = listSelectInOutGubun.get(0).getInOutGubun();
	            		tFkocs = listSelectInOutGubun.get(0).getFkocs();
	            	}
	            	//
	            	if(StringUtils.isEmpty(grdResult.getCplResult())){
	            		cpl3020Repository.updateCPL3020U00Cpl3020CplResult(request.getUserId(), sysDate, hospCode, pkcpl3020);
						cpl3010Repository.updateCPL3020U00CPL3010CplResult(request.getUserId(), sysDate, null, null, hospCode, grdResult.getLabNo(), grdResult.getSpecimenSer());
						ocs5010Repository.callPrOcsUpdateResult(hospCode, tInOutGubun, tFkocs, "", sysDate);
	            	}else{
	            		cpl3020Repository.updateCPL3020U02Cpl3020CplResult(request.getUserId(), sysDate, sysTime, hospCode, grdResult.getCplResult(), pkcpl3020);
	            		cpl3010Repository.updateCPL3020U00CPL3010Else(request.getUserId(), sysDate, sysTime, hospCode, grdResult.getLabNo(), grdResult.getSpecimenSer());
		            	
		            	ocs5010Repository.callPrOcsUpdateResult(hospCode, tInOutGubun, tFkocs, "CPL", sysDate);
	            	}
	            	cpl3020Repository.updateCPL3020U00Cpl3020Final(request.getUserId(),sysDate, grdResult.getComments(), grdResult.getDisplayYn(), hospCode, pkcpl3020);
				}
			}
		}
		// 2.
		List<CplsModelProto.CPL3020U00GrdNoteUpdateInfo> listGrdNote = request.getGrdNoteUpdateItemInfoList();
		if(!CollectionUtils.isEmpty(listGrdNote)){
			for (CplsModelProto.CPL3020U00GrdNoteUpdateInfo grdNote : listGrdNote){
				if(grdNote.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue()) || grdNote.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					String tExistYn = "";
					String retVal = cpl2090Repository.checkExitCPL3020U02ExecuteCase2(hospCode, grdNote.getJundalGubun(), grdNote.getSpecimenSer());
					if (!StringUtils.isEmpty(retVal)){
						tExistYn = retVal;
					}
					if("Y".equalsIgnoreCase(tExistYn)){
						cpl2090Repository.updateCPL3020U02ExecuteCase2(request.getUserId(),sysDate, grdNote.getCode(), grdNote.getNote(), 
								grdNote.getEtcComment(), hospCode, grdNote.getJundalGubun(), grdNote.getSpecimenSer());
					}else{
						Cpl2090 cpl2090 = new Cpl2090();
	            		Date sysdate = new Date();
	            		cpl2090.setSysDate(sysdate);
	            		cpl2090.setSysId(request.getUserId());
	            		cpl2090.setUpdDate(sysdate);
	            		cpl2090.setUpdId(request.getUserId());
	            		cpl2090.setHospCode(hospCode);
	            		cpl2090.setJundalPart(grdNote.getJundalGubun());
	            		cpl2090.setSpecimenSer(grdNote.getSpecimenSer());
	            		cpl2090.setCode(grdNote.getCode());
	            		cpl2090.setNote(grdNote.getNote());
	            		cpl2090.setEtcComment(grdNote.getEtcComment());
	            		cpl2090Repository.save(cpl2090);
					}
				}
			}
		}
		//3.
		List<CplsModelProto.CPL3020U00GrdPaListItemInfo> listGrdPa = request.getGrdPaItemInfoList();
		if(!CollectionUtils.isEmpty(listGrdPa)){
			for (CplsModelProto.CPL3020U00GrdPaListItemInfo grdPa : listGrdPa){
				if("Y".equalsIgnoreCase(grdPa.getBatchConfirmYn()) && grdPa.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					cpl3020Repository.callPrCplAutoConfirmUpdate(hospCode, grdPa.getSpecimenSer(), request.getGumsaja(), "Y");
				}
			}
		}
		
		response.setResult(true);
		return response;
	}

}
