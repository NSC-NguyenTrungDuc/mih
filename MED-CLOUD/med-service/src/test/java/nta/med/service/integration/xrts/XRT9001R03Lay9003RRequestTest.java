package nta.med.service.integration.xrts;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class XRT9001R03Lay9003RRequestTest extends MessageRequestTest{

	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		// TEST Xrt0122Q00LayDupMRequest MED-4174
//		XrtsServiceProto.Xrt0122Q00LayDupMRequest request = XrtsServiceProto.Xrt0122Q00LayDupMRequest
//				.newBuilder()
//				.build();
//		sentRequestToMedApp(request, XrtsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		// TEST XrtsServiceProto.XRT0201U00FwkOrdDanuiNameRequest MED-4229
//		XrtsServiceProto.XRT0201U00FwkOrdDanuiNameRequest request = XrtsServiceProto.XRT0201U00FwkOrdDanuiNameRequest
//				.newBuilder()
//				.setHangmogCode("620004305")
//				.build();
//		sentRequestToMedApp(request, XrtsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
		// BASMANAGE 1, ,001,0017
		CommonModelProto.DataStringListItemInfo .Builder builder = CommonModelProto.DataStringListItemInfo .newBuilder();
		builder.setDataValue("");
		
		OcsaServiceProto.OCS0103U16GrdSangyongOrderRequest request = OcsaServiceProto.OCS0103U16GrdSangyongOrderRequest
				.newBuilder()
				.setUser("K01OCS")
				.setCodeYn("Y")
				.setIoGubun("O")
				.setOrderDate("2015/10/12")
				.setWonnaeDrgYn("%")
				.setOrderGubun("X")
				.build();
		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}