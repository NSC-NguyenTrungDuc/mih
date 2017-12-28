package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00xEditGridCellRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00xEditGridCellResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00xEditGridCellHandler extends ScreenHandler<InpsServiceProto.INP1003U00xEditGridCellRequest, InpsServiceProto.INP1003U00xEditGridCellResponse> {

	@Resource
	private Bas0102Repository bas0102Repository;	

	@Override
	public INP1003U00xEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00xEditGridCellRequest request) throws Exception {
		InpsServiceProto.INP1003U00xEditGridCellResponse.Builder response = InpsServiceProto.INP1003U00xEditGridCellResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<ComboListItemInfo> listInfoByAnamune = bas0102Repository.getCodeNameListItem(hospCode, "ANAMUNE_PURPOSE", "1", language);
		List<ComboListItemInfo> listInfoByIpwon = bas0102Repository.getCodeNameListItem(hospCode, "IPWON_RTN2", "1", language);
		List<ComboListItemInfo> listInfoByReser = bas0102Repository.getCodeNameListItem(hospCode, "RESER_END_TYPE", "1", language);
		List<ComboListItemInfo> listInfoBySogye = bas0102Repository.getCodeNameListItem(hospCode, "SOGYE_YN", "1", language);
		List<ComboListItemInfo> listInfoHope = bas0102Repository.getCodeNameListItem(hospCode, "HOPE_ROOM", "1", language);
		
		// listInfoByAnamune
		if(!CollectionUtils.isEmpty(listInfoByAnamune)){
			for (ComboListItemInfo info : listInfoByAnamune) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addXEditGridCell20(infoProto);
			}
		}
		
		// listInfoByIpwon
		if (!CollectionUtils.isEmpty(listInfoByIpwon)) {
			for (ComboListItemInfo info : listInfoByIpwon) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addXEditGridCell9(infoProto);
			}
		}
		// listInfoByReser
		if (!CollectionUtils.isEmpty(listInfoByReser)) {
			for (ComboListItemInfo info : listInfoByReser) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addXEditGridCell13(infoProto);
			}
		}

		// listInfoBySogye
		if (!CollectionUtils.isEmpty(listInfoBySogye)) {
			for (ComboListItemInfo info : listInfoBySogye) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addXEditGridCell26(infoProto);
			}
		}

		// listInfoHope
		if (!CollectionUtils.isEmpty(listInfoBySogye)) {
			for (ComboListItemInfo info : listInfoHope) {
				CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, infoProto, language);
				response.addXEditGridCell28(infoProto);
			}
		}
		
		return response.build();
	}
	

}
