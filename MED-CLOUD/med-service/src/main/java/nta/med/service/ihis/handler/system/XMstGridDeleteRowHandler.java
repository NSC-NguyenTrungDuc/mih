package nta.med.service.ihis.handler.system;

import java.math.BigInteger;

import javax.annotation.Resource;

import nta.med.core.config.Configuration;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.XMstGridDeleteRowRequest;
import nta.med.service.ihis.proto.SystemServiceProto.XMstGridDeleteRowResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class XMstGridDeleteRowHandler extends ScreenHandler<SystemServiceProto.XMstGridDeleteRowRequest, SystemServiceProto.XMstGridDeleteRowResponse> { 
	private static final Log LOGGER = LogFactory.getLog(XMstGridDeleteRowHandler.class); 
	@Resource                                                                                                       
	private CommonRepository commonRepository;  
	@Autowired
	private Configuration configuration;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public XMstGridDeleteRowResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, XMstGridDeleteRowRequest request)
			throws Exception  { 
		LOGGER.info("call XMstGridDeleteRowHandler");
  	   	SystemServiceProto.XMstGridDeleteRowResponse.Builder response = SystemServiceProto.XMstGridDeleteRowResponse.newBuilder();                      
		String table = request.getTableName();
		if(table.contains("'")){
			table = table.replace("'", "");
		}
		if(table.contains("'")){
			table = table.replace("\\", "");
		}
		String where = request.getWhereCmd();
		if(where.contains("'")){
			where = where.replace("\\", "");
		}
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCode())){
			hospCode = request.getHospCode();
		}
		String columnName = commonRepository.checkColumnExistOnTable(table.toUpperCase(), configuration.getSchema());
		BigInteger result = commonRepository.getXMstGridDeleteRowInfo(table.toUpperCase(), where.toUpperCase(), hospCode, columnName);
		if(!StringUtils.isEmpty(result)){
			response.setResult(result.toString());
		}
		return response.build();
	}
}