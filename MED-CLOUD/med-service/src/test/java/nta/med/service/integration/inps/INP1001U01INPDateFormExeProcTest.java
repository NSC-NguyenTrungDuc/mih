package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01INPDateFormExeProcTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001U01INPDateFormExeProcRequest.Builder request = InpsServiceProto.INP1001U01INPDateFormExeProcRequest.newBuilder();
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("1"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("2"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("2011/01/01"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("2018/01/01"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("5"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("6"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("7"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("8"));
		request.addInpList(CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue("9"));
		
		sentRequestToMedApp(request.build(), InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
