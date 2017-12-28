package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.model.ihis.bass.BAS0311Q01GrdBAS0311Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0311Q01GrdBAS0311Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0311Q01GrdBAS0311Response;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class BAS0311Q01GrdBAS0311Handler extends ScreenHandler<BassServiceProto.BAS0311Q01GrdBAS0311Request, BassServiceProto.BAS0311Q01GrdBAS0311Response> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0311Q01GrdBAS0311Handler.class);
	
	@Resource                                   
	private Bas0310Repository bas0310Repository;
	
	public boolean isValid(BassServiceProto.BAS0311Q01GrdBAS0311Request request, Vertx vertx, String clientId, String sessionId) {
		if(StringUtils.isEmpty(request.getOffset())){
			return false;
		}
		return true;
	}
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0311Q01GrdBAS0311Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0311Q01GrdBAS0311Request request) throws Exception {
  	   	BassServiceProto.BAS0311Q01GrdBAS0311Response.Builder response = BassServiceProto.BAS0311Q01GrdBAS0311Response.newBuilder();                      
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		List<BAS0311Q01GrdBAS0311Info> listItem = bas0310Repository.getBAS0311Q01GrdBAS0311Info(getHospitalCode(vertx, sessionId), request.getSearchWord(), request.getNuGroup(), startNum, CommonUtils.parseInteger(request.getOffset()));
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0311Q01GrdBAS0311Info item : listItem){
				BassModelProto.BAS0311Q01GrdBAS0311Info.Builder builder = BassModelProto.BAS0311Q01GrdBAS0311Info.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addItemInfo(builder);
			}
		}
		return response.build();
	} 
}
