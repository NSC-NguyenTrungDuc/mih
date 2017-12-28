package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR1020Q00grdPalistInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00grdPalistRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00grdPalistResponse;

@Service
@Scope("prototype")
public class NUR1020Q00grdPalistHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00grdPalistRequest, NuriServiceProto.NUR1020Q00grdPalistResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00grdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00grdPalistRequest request) throws Exception {
		
		NuriServiceProto.NUR1020Q00grdPalistResponse.Builder response = NuriServiceProto.NUR1020Q00grdPalistResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1020Q00grdPalistInfo> items = inp1001Repository.getNUR1020Q00grdPalistInfo(hospCode,
				request.getHoDong(), request.getDate(), request.getA(), request.getB(), request.getC(), request.getD(), startNum, offset);
		 
		for (NUR1020Q00grdPalistInfo item : items) {
			NuriModelProto.NUR1020Q00grdPalistInfo.Builder info = NuriModelProto.NUR1020Q00grdPalistInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
