package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.nur.Nur1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocso.OCS1003R02DTHospListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02DTListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003R02LayR02ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS1003R02LayR02QueryStartingRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS1003R02LayR02QueryStartingResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OCS1003R02LayR02QueryStartingHandler extends ScreenHandler<OcsoServiceProto.OCS1003R02LayR02QueryStartingRequest, OcsoServiceProto.OCS1003R02LayR02QueryStartingResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(OCS1003R02LayR02QueryStartingHandler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	@Resource
	private Bas0001Repository bas0001Repository;
	@Resource
	private Nur1003Repository nur1003Repository;

	@Override
	public OCS1003R02LayR02QueryStartingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS1003R02LayR02QueryStartingRequest request) throws Exception {
		LOGGER.info("Call Handler: OCS1003R02LayR02QueryStartingHandler");
		OcsoServiceProto.OCS1003R02LayR02QueryStartingResponse.Builder response = OcsoServiceProto.OCS1003R02LayR02QueryStartingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Double fkout1001 = CommonUtils.parseDouble(request.getFkout1001());
		String oErr = "";
		String oGwa = "";
		String oGwaName = "";
		String oBunho = "";
		String oSuname = "";
		String oBalheangDate = "";
		String oBirth = "";
		String oNaewonDate = "";
		String oBunho1 = "";
		String oDangilGumsaResultYn = "";
		String oJaedanName = "";
		String oHospName = "";
		String oTel = "";
		String oHomePage = "";
		
		List<OCS1003R02DTListItemInfo> listInfo = out0101Repository.getOCS1003R02DTListItemInfo(hospCode, language, request.getGwa(), request.getNaewonDate(), 
				request.getBunho(), request.getDoctor(), request.getNaewonType(), request.getJubsuNo());
		if(!CollectionUtils.isEmpty(listInfo)){
			oGwa = listInfo.get(0).getGwa() != null ? listInfo.get(0).getGwa() : "";
			oGwaName = listInfo.get(0).getGwaName() != null ? listInfo.get(0).getGwaName() : "";
			oBunho = listInfo.get(0).getBunho() != null ? listInfo.get(0).getBunho() : "";
			oSuname = listInfo.get(0).getSuname() != null ? listInfo.get(0).getSuname() : "";
			oBalheangDate = listInfo.get(0).getBalheangDate() != null ? listInfo.get(0).getBalheangDate() : "";
			oBirth = listInfo.get(0).getBirth() != null ? listInfo.get(0).getBirth() : "";
			oNaewonDate = listInfo.get(0).getNaewonDate() != null ? listInfo.get(0).getNaewonDate() : "";
			oBunho1 = listInfo.get(0).getBunho1() != null ? listInfo.get(0).getBunho1() : "";
			oDangilGumsaResultYn = listInfo.get(0).getDangilGumsaResultYn() != null ? listInfo.get(0).getDangilGumsaResultYn() : "";
		}
		List<OCS1003R02DTHospListItemInfo> listHosp = bas0001Repository.getOCS1003R02DTHospListItemInfo(hospCode, language);
		if(!CollectionUtils.isEmpty(listHosp)){
			oJaedanName = listHosp.get(0).getJaedanName() != null ? listHosp.get(0).getJaedanName() : "";
			oHospName = listHosp.get(0).getSimpleYoyangName() != null ? listHosp.get(0).getSimpleYoyangName() : "";
			oTel = listHosp.get(0).getTel() != null ? listHosp.get(0).getTel() : "";
			oHomePage = listHosp.get(0).getHomepage() != null ? listHosp.get(0).getHomepage() : "";
		}
		oErr = nur1003Repository.callPrNurMakePatienInfo(hospCode, language, request.getBunho(), fkout1001, request.getUserId());
		if(!StringUtils.isEmpty(oErr)){
			response.setIoFlag(oErr);
		}
		List<OCS1003R02LayR02ListItemInfo> listR02 = nur1003Repository.getOCS1003R02LayOutListItemInfo(hospCode, oGwa, oGwaName, oBunho, oSuname, oBalheangDate, oBirth, 
				oNaewonDate, oBunho1, oDangilGumsaResultYn, oJaedanName, oHospName, oTel, oHomePage, fkout1001);
		if(!CollectionUtils.isEmpty(listR02)){
			for(OCS1003R02LayR02ListItemInfo item : listR02){
				OcsoModelProto.OCS1003R02LayR02ListItemInfo.Builder info = OcsoModelProto.OCS1003R02LayR02ListItemInfo.newBuilder();
		  		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayr02List(info);
			}
		}
		return response.build();
	}                                                                                                                 
}