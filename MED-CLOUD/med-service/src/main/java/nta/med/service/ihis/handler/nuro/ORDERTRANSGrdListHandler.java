package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.dao.medi.inp.Inp3010Repository;
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSGrdListHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdListRequest, NuroServiceProto.ORDERTRANSGrdListResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdListHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;      
	@Resource 
	private Inp3010Repository inp3010Repository;
	@Resource
	private Ocs2015Repository ocs2015Repository;
	@Resource
	private Nur1014Repository nur1014Repository;
	@Resource
	private Inp2004Repository inp2004Repository;
	                                                                                                                
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSGrdListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getActingDate()) && DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdListRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdListResponse.Builder response = NuroServiceProto.ORDERTRANSGrdListResponse.newBuilder();
		List<ORDERTRANSGrdListInfo> listResult = new ArrayList<ORDERTRANSGrdListInfo>();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		switch (request.getStr()) {
		case "0":
			if("N".equalsIgnoreCase(request.getMSendYn())){
				listResult = ocs2003Repository.getORDERTRANSGrdListInfoCase0ElseEqualN(hospCode, language, request.getIoGubun(), request.getSendYn(), request.getBunho());
			}else{
				listResult = inp3010Repository.getORDERTRANSGrdListInfoCase0ElseElse(hospCode, language, request.getIoGubun(), request.getSendYn(), request.getBunho());
			}
			break;
		case "1":
			listResult = ocs2015Repository.getORDERTRANSGrdListInfoCase1(hospCode, language, request.getIoGubun(), request.getSendYn(), request.getBunho(), request.getActingDate());
			break;
		case "2":
			listResult = nur1014Repository.getORDERTRANSGrdListInfoCase2(hospCode, language, request.getIoGubun(), request.getSendYn(), request.getBunho());
			break;
		case "3":
			listResult = inp2004Repository.getORDERTRANSGrdListInfoCase3(hospCode, language, request.getIoGubun(), request.getSendYn(), request.getBunho(), request.getActingDate());
			break;
		default:
			break;
		}
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdListInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdListInfo.Builder info = NuroModelProto.ORDERTRANSGrdListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				if (item.getPkout() != null) {
					info.setPkout(String.format("%.0f",item.getPkout()));
				}
				response.addGrdItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}