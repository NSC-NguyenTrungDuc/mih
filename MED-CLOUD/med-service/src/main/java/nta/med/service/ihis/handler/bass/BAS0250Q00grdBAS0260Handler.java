package nta.med.service.ihis.handler.bass;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00grdBAS0260Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250Q00grdBAS0260Response;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0250Q00grdBAS0260Handler extends ScreenHandler<BassServiceProto.BAS0250Q00grdBAS0260Request, BassServiceProto.BAS0250Q00grdBAS0260Response> {                     
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0250Q00grdBAS0260Response handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BAS0250Q00grdBAS0260Request request) throws Exception {
		BassServiceProto.BAS0250Q00grdBAS0260Response.Builder response = BassServiceProto.BAS0250Q00grdBAS0260Response.newBuilder(); 
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
  	    Date buseoYmd = DateUtil.toDate(request.getBuseoYmd(), DateUtil.PATTERN_YYMMDD);
  	    
		List<ComboListItemInfo> listBAS0250Q00grdBAS0260Department = bas0260Repository.getBAS0250Q00grdBAS0260Department(hospCode, language, buseoYmd, request.getGumjinHodong());
		if(!CollectionUtils.isEmpty(listBAS0250Q00grdBAS0260Department)){
			for(ComboListItemInfo item : listBAS0250Q00grdBAS0260Department){
				CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(builder);
			}
		}
		
		return response.build();
	}                                                                                                                 
}