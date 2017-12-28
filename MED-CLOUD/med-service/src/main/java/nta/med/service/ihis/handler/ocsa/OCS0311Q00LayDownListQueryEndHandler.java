package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0118Repository;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayDownListQueryEndResInfo;
import nta.med.data.model.ihis.system.PrOcsConvertHangmogCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0311Q00LayDownListQueryEndReqInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LayDownListQueryEndRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LayDownListQueryEndResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311Q00LayDownListQueryEndHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311Q00LayDownListQueryEndRequest, OcsaServiceProto.OCS0311Q00LayDownListQueryEndResponse> {                     
	@Resource                                                                                                       
	private Ocs0118Repository ocs0118Repository;    
	@Resource
	private Ocs0103Repository ocs0103Repository;
	                                                                                                                
	@Override
	@Transactional
	public OCS0311Q00LayDownListQueryEndResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311Q00LayDownListQueryEndRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0311Q00LayDownListQueryEndResponse.Builder response = OcsaServiceProto.OCS0311Q00LayDownListQueryEndResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		int x = 0;
		for(OCS0311Q00LayDownListQueryEndReqInfo info : request.getLayDownReqItemList()){
			if("Y".equalsIgnoreCase(info.getBulyongYn())){
				Date giJunDate = DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD);
				PrOcsConvertHangmogCodeInfo prResult = ocs0118Repository.callPrOcsConvertHangmogCode(hospCode, "2", "1",
					info.getSetHangmogCode(), "", giJunDate, "2", null, null);
				String convertHangmogCode = null;
				if(prResult != null && !StringUtils.isEmpty(prResult.getIoHangmogCode())){
					convertHangmogCode = prResult.getIoHangmogCode();
				}
				String checkHangmogCode = info.getSetHangmogCode() == null ? "X" : info.getSetHangmogCode();
				String checkConvertHangmogCode = convertHangmogCode == null ? "X" : convertHangmogCode;
				if(!checkHangmogCode.equalsIgnoreCase(checkConvertHangmogCode)){
					List<OCS0311Q00LayDownListQueryEndResInfo> listLayDown = ocs0103Repository.getOCS0311Q00LayDownListQueryEndResInfo(hospCode, language, convertHangmogCode);
					if(!CollectionUtils.isEmpty(listLayDown)){
						for(OCS0311Q00LayDownListQueryEndResInfo item : listLayDown){
							OcsaModelProto.OCS0311Q00LayDownListQueryEndResInfo.Builder layDownInfo = OcsaModelProto.OCS0311Q00LayDownListQueryEndResInfo.newBuilder();
							BeanUtils.copyProperties(item, layDownInfo, getLanguage(vertx, sessionId));
							layDownInfo.setRowIdx(Integer.toString(x++));
							response.addLayDownResItem(layDownInfo);
						}
					}
				}
			}
		}
		return response.build();
	}

}