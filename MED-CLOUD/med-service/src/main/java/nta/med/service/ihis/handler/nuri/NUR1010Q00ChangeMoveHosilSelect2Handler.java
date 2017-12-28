package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00ChangeMoveHosilSelect2Handler extends ScreenHandler<NuriServiceProto.NUR1010Q00ChangeMoveHosilSelect2Request, NuriServiceProto.NUR1010Q00ChangeMoveHosilSelect2Response> {   
	
	@Resource                                   
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00ChangeMoveHosilSelect2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00ChangeMoveHosilSelect2Request request) throws Exception {
				
		NuriServiceProto.NUR1010Q00ChangeMoveHosilSelect2Response.Builder response = NuriServiceProto.NUR1010Q00ChangeMoveHosilSelect2Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String junpyoDate = request.getJunpyoDate();
		
		if(StringUtils.isEmpty(junpyoDate) || junpyoDate == ""){
			junpyoDate = DateUtil.getCurrentDateTime(DateUtil.PATTERN_YYMMDD);
		}
		
		List<String> result = bas0250Repository.getNUR1010Q00ChangeMoveHosilSelect2(hospCode, junpyoDate, request.getToHoCode(), request.getToHoDong());
		
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			for(String item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item);
				response.addListMovehosil2(info);
			}
		}
		
		return response.build();
	}
}
