package nta.med.service.ihis.handler.system;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoGetNaewonYNRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoGetNaewonYNResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
public class OcsoGetNaewonYNHandler extends ScreenHandler <SystemServiceProto.OcsoGetNaewonYNRequest, SystemServiceProto.OcsoGetNaewonYNResponse> {                             
	
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoGetNaewonYNResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OcsoGetNaewonYNRequest request)
			throws Exception {                                                                   
		SystemServiceProto.OcsoGetNaewonYNResponse.Builder response = SystemServiceProto.OcsoGetNaewonYNResponse.newBuilder();    
  	  	String hospCode = getHospitalCode(vertx, sessionId);
		String naewonYn = null;
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		if("".equals(request.getNaewonDate()) && "".equals(request.getBunho())){
			List<String> listNaewonYn = out1001Repository.OcsaOCS0503U00GetNaewonYn(hospCode, pkout1001);
			if(!CollectionUtils.isEmpty(listNaewonYn)){
				naewonYn = listNaewonYn.get(0);
			}
		}else{
			Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
			naewonYn = out1001Repository.getOcsoGetNaewonYn(hospCode, request.getBunho(), naewonDate, pkout1001);	
		}
		
		if(!StringUtils.isEmpty(naewonYn)){
			response.setNaewonYn(naewonYn);
		}
		return response.build();
	}
}
