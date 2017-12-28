package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0230Repository;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.dao.medi.ifs.Ifs0001Repository;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0001Info;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadColumnCodeNameRequest;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadColumnCodeNameResponse;

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
public class ComBizLoadColumnCodeNameHandler extends ScreenHandler<BassServiceProto.ComBizLoadColumnCodeNameRequest, BassServiceProto.ComBizLoadColumnCodeNameResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ComBizLoadColumnCodeNameHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0002Repository ifs0002Repository;                 
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;   
	@Resource                                                                                                       
	private Ifs0001Repository ifs0001Repository;   
	@Resource
	private Bas0230Repository bas0230Repository;
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public ComBizLoadColumnCodeNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ComBizLoadColumnCodeNameRequest request) throws Exception {
  	   	BassServiceProto.ComBizLoadColumnCodeNameResponse.Builder response = BassServiceProto.ComBizLoadColumnCodeNameResponse.newBuilder();                      
		String result = "";
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		switch (request.getColName()) {
		case "code_type":
			List<ComBizLoadIFS0001Info> listComBizLoad =  ifs0001Repository.getComBizLoadIFS0001ListItem(hospitalCode, request.getArgu1());
			if(!CollectionUtils.isEmpty(listComBizLoad)){
				result = listComBizLoad.get(0).getCodeTypeName();
			}
			break;
		case "code":
			result = ifs0002Repository.getIfs003U03FbxSearchGubun(hospitalCode, request.getArgu2(), "");
			break;
		case "bun_code":
			result = bas0230Repository.getBunNameItemInfo(hospitalCode, language, request.getArgu1(), request.getArgu2(), true);
			break;
		case "sg_code":
			List<OCS0103U00LayCommonInfo> list = bas0310Repository.getOCS0103U00LayCommonInfo(hospitalCode, DateUtil.toDate(request.getArgu2(), DateUtil.PATTERN_YYMMDD), request.getArgu1(), request.getArgu2());
			if(!CollectionUtils.isEmpty(list)){
				result = list.get(0).getName();
			}
			break;
		default:
			break;
		}
		if(!StringUtils.isEmpty(result)){
			response.setValue(result);
		}
		return response.build();
	}                                                                                                            
}