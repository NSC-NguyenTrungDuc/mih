package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00cboHodongRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00cboHodongResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00cboHodongHandler extends ScreenHandler<InpsServiceProto.INP1003U00cboHodongRequest, InpsServiceProto.INP1003U00cboHodongResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;	

	@Override
	public INP1003U00cboHodongResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00cboHodongRequest request) throws Exception {
		InpsServiceProto.INP1003U00cboHodongResponse.Builder response = InpsServiceProto.INP1003U00cboHodongResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String reserDate = request.getReserDate();
		String language = getLanguage(vertx, sessionId);

		List<ComboListItemInfo> listInfo = bas0260Repository.getINP1003U00cboHodong(hospCode, language, reserDate);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		if(!CollectionUtils.isEmpty(listInfo)){
			for (ComboListItemInfo info : listInfo) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addGrdMasterItem(infoProto);
			}
		}
		
		return response.build();
	}
	

}
