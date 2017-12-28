package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99PaPrnInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PaPrnHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PaPrnRequest, DrgsServiceProto.DRG3010P99PaPrnResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99PaPrnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PaPrnRequest request) throws Exception{

		DrgsServiceProto.DRG3010P99PaPrnResponse.Builder response = DrgsServiceProto.DRG3010P99PaPrnResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<DRG3010P99PaPrnInfo> result = drg3010Repository.getDRG3010P99PaPrnInfo(hospCode, language, request.getHoDong(), request.getFromDate(), request.getToDate(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for (DRG3010P99PaPrnInfo item : result){
				DrgsModelProto.DRG3010P99PaPrnInfo.Builder info = DrgsModelProto.DRG3010P99PaPrnInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);;
				response.addListGrdpaprn(info);
			}
		}
			
		return response.build();
	}
}