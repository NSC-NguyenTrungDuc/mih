package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoLoadCht0110Request;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoLoadCht0110Response;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class OcsoLoadCht0110Handler extends ScreenHandler <SystemServiceProto.OcsoLoadCht0110Request, SystemServiceProto.OcsoLoadCht0110Response> {                             
	
	@Resource                                                                                                       
	private Cht0110Repository cht0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoLoadCht0110Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OcsoLoadCht0110Request request)
			throws Exception  {                                                                   
  	   	SystemServiceProto.OcsoLoadCht0110Response.Builder response = SystemServiceProto.OcsoLoadCht0110Response.newBuilder();                      
		List<ComboListItemInfo> listItem = cht0110Repository.getOcsoLoadCht0110(request.getSangCode(), request.getGijunDate());
		if(!CollectionUtils.isEmpty(listItem)){
			for(ComboListItemInfo item : listItem){
				SystemModelProto.OcsoLoadCht0110Info.Builder builder = SystemModelProto.OcsoLoadCht0110Info.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					builder.setSangCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					builder.setSangName(item.getCodeName());
				}
				response.addCht0110Info(builder);
			}
		}
		return response.build();
	}
}
