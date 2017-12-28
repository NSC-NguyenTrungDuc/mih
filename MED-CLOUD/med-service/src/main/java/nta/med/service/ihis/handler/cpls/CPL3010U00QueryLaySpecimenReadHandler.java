package nta.med.service.ihis.handler.cpls;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QueryLaySpecimenReadRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class CPL3010U00QueryLaySpecimenReadHandler extends ScreenHandler <CplsServiceProto.CPL3010U00QueryLaySpecimenReadRequest, CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse> {                     
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public CPL3010U00QueryLaySpecimenReadResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U00QueryLaySpecimenReadRequest request) throws Exception {                                                                   
  	   	CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse.Builder response = CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	response = queryLaySpecimenRead(request, hospCode);
  	   	return response.build();
	}                                      
	
	private CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse.Builder queryLaySpecimenRead(CplsServiceProto.CPL3010U00QueryLaySpecimenReadRequest request, String hospCode){
		CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse.Builder response = CplsServiceProto.CPL3010U00QueryLaySpecimenReadResponse.newBuilder();
		String insertOk = "N";
		String alreadyJubsu = "N";
		String flag = "";
		
    	insertOk = cpl2010Repository.getYValueBySpecimentSerAndJubsuDateNull(hospCode,request.getSpecimenReadValue()) ;
		if("Y".equalsIgnoreCase(insertOk)){
			Date gumJubsuDate = DateUtil.toDate(request.getGumJubsuDate(), DateUtil.PATTERN_YYMMDD);
			String gumJubsuTime = DateUtil.getCurrentHH24MI();
			cpl2010Repository.updateCPL3010U00QueryLaySpecimenReadUpdate(gumJubsuDate, gumJubsuTime,request.getPartJubsuja(),hospCode,request.getSpecimenReadValue());
			
			List<String> listJundalGubun= cpl2010Repository.getCPL3010U00QueryLaySpecimenReadSelectJundalGubun(hospCode,request.getSpecimenReadValue());
			if(!CollectionUtils.isEmpty(listJundalGubun)){
				for(String item : listJundalGubun){
					 flag= cpl2010Repository.callCPL2010U00PrCplPartJubsu(hospCode,
							 request.getSpecimenReadValue(),item ,gumJubsuDate,gumJubsuTime,request.getPartJubsuja(),request.getPartJubsuja());
				}
			}
			
			response.setInsertOk(insertOk == null ? "N" : insertOk);
			response.setAlreadyJubsu(alreadyJubsu == null ? "N" : alreadyJubsu);
			response.setFlag(flag == null ? "" : flag);
			return response;
		}
		
		alreadyJubsu = cpl2010Repository.getYValueBySpecimentSerAndJubsuDateNotNull(hospCode,request.getSpecimenReadValue()) ;
		if("N".equalsIgnoreCase(alreadyJubsu)){
		String	oAlreadyJubsu1 = cpl2010Repository.getCPL3010U00GetZValue(hospCode,request.getSpecimenReadValue());
		  if(!StringUtils.isEmpty(oAlreadyJubsu1)){
			  alreadyJubsu =  oAlreadyJubsu1;
		  }
		}
		response.setInsertOk(insertOk == null ? "N" : insertOk);
		response.setAlreadyJubsu(alreadyJubsu == null ? "N" : alreadyJubsu);
		response.setFlag(flag == null ? "" : flag);
		return response;
	}
}